using FirstLook.Response;

namespace FirstLook.Services
{
    public class NewFeatures : INewFeatures
    {
        public ResponseData<IEnumerable<KeyValuePair<string, int>>> AggregateByScore()
        {
            (string id, int score)[] data =
            [
                ("0",42),
                ("1",11),
                ("2",12),
                ("1",19),
                ("0",18),
            ];

            var result = data.AggregateBy(seed: 0,
                func: (totalScore, curr) => totalScore += curr.score,
                keySelector: entry => entry.id);
            return new ResponseData<IEnumerable<KeyValuePair<string, int>>>(true, 200, "true", result);


        }

        public ResponseData<string> CountByStringItem()
        {
            var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var now = DateTime.UtcNow;
            KeyValuePair<string, int> res = text
                .Split(new[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLowerInvariant())
                .CountBy(word => word)
                .MaxBy(a=>a.Value);
            var data = $"{res.Key} : {res.Value}";
            var timespan = DateTime.UtcNow - now;
            return new ResponseData<string>(true,200,"true", data);
        }

        public ResponseData<IEnumerable<KeyValuePair<int,int>>> CountByItem()
        {
            var numbers = Enumerable.Range(0, 100).Select(_ => new Random().Next(1, 100)).ToArray();
            var now = DateTime.UtcNow;
            var res = numbers
                .CountBy(number => number);
            var timespan = DateTime.UtcNow - now;
            return new ResponseData<IEnumerable<KeyValuePair<int, int>>>(true, 200, "true", res);
        }

        public ResponseData<Dictionary<int, string>> IndexItem()
        {
            Dictionary<int,string> values = new Dictionary<int,string>();
            IEnumerable<string> lines = File.ReadAllLines("file.txt");
            foreach ((int index,string line) in lines.Index()) 
            {
                values.Add(index + 1, line);
            }
            return new ResponseData<Dictionary<int, string>>(true, 200, "true", values);
        }
    }
}

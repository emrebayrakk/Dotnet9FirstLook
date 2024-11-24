using FirstLook.Response;

namespace FirstLook.Services
{
    public interface INewFeatures
    {
        ResponseData<IEnumerable<KeyValuePair<int, int>>> CountByItem();
        ResponseData<string> CountByStringItem();
        ResponseData<IEnumerable<KeyValuePair<string, int>>> AggregateByScore();
        ResponseData<Dictionary<int, string>> IndexItem();
    }
}

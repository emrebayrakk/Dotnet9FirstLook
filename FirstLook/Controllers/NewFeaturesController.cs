using FirstLook.Response;
using FirstLook.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstLook.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NewFeaturesController : ControllerBase
    {
        private readonly INewFeatures _newFeatures;

        public NewFeaturesController(INewFeatures newFeatures)
        {
            _newFeatures = newFeatures;
        }

        [HttpGet("GetString")]
        [ProducesResponseType(typeof(ResponseData<string>), StatusCodes.Status200OK)]
        public ResponseData<string> GetString()
        {
            var res = _newFeatures.CountByStringItem();
            return res;
        }
        [HttpGet("GetNumbers")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<KeyValuePair<int, int>>>), StatusCodes.Status200OK)]
        public ResponseData<IEnumerable<KeyValuePair<int, int>>> GetNumbers()
        {
            var res = _newFeatures.CountByItem();
            return res;
        }
        [HttpGet("GetScore")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<KeyValuePair<string, int>>>), StatusCodes.Status200OK)]
        public ResponseData<IEnumerable<KeyValuePair<string, int>>> GetScore()
        {
            var res = _newFeatures.AggregateByScore();
            return res;
        }
        [HttpGet("GetIndex")]
        [ProducesResponseType(typeof(ResponseData<Dictionary<int, string>>), StatusCodes.Status200OK)]
        public ResponseData<Dictionary<int, string>> GetIndex()
        {
            var res = _newFeatures.IndexItem();
            return res;
        }
    }
}

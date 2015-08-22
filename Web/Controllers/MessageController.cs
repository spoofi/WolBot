using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Logic;
using Telegram.Bot.Types;

namespace Web.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/wol")]
        public OkResult Post([FromBody]Update value)
        {
            Task.Run(() => new Handler().Handle(value.Message));
            return Ok();
        }
    }
}

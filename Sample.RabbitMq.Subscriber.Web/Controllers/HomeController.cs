using EasyNetQ;
using EasyNetQ.Topology;
using System.Web.Mvc;

namespace Sample.RabbitMq.Subscriber.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvancedBus _advancedBus;
        private readonly IExchange _exchange;

        public HomeController(IAdvancedBus advancedBus, IExchange exchange)
        {
            _advancedBus = advancedBus;
            _exchange = exchange;
        }
        public ActionResult Index(string type)
        {
            ViewBag.Type = type;
            return View();
        }

        public ActionResult GetMessages(string type)
        {
            if (type == null)
            {
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { Number = "-1" }
                };
            }

            var queue = _advancedBus.QueueDeclare(string.Format("FirstScreen.Queue.{0}", type));
            _advancedBus.Bind(_exchange, queue, type);

            var result = _advancedBus.Get<string>(queue);

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { Number = result != null ? result.Message.Body : "-1" }
            };
        }
    }
}
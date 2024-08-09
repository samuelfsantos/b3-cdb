using B3.Cdb.Application.Interfaces;
using B3.Cdb.Application.Requests;
using B3.Cdb.Domain.Notifications;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace B3.Cdb.Api.Controllers
{
    [RoutePrefix("api/v1/investmentos")]
    public class InvestimentosController : ApiController
    {
        private readonly IInvestimentoApplication _investimentoApplication;
        private readonly INotifier _notifier;

        public InvestimentosController(IInvestimentoApplication investimentoApplication, INotifier notifier)
        {
            _investimentoApplication = investimentoApplication;
            _notifier = notifier;
        }


        [HttpPost]
        [Route("cdb")]
        public IHttpActionResult CalcularInvestimento([FromBody] CalculoInvestimentoRequest request)
        {
            var resultado = _investimentoApplication.Calcular(request);

            if (_notifier.HasNotifications())
            {
                var mensagens = _notifier.GetNotifications().Select(n => n.Message).ToArray();

                return Content(HttpStatusCode.BadRequest, mensagens);
            }

            return Ok(resultado);
        }

        [HttpGet]
        [Route("teste")]
        public IHttpActionResult Teste()
        {
            return Ok("Api está funcionando!");
        }
    }
}

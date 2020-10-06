using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Flight_Planner.Web.Models
{
    public class BadRequest : IHttpActionResult
    {
        public List<string> Messages { get; private set; }
        public HttpRequestMessage Request { get; private set; }

        public BadRequest(List<string> messages, HttpRequestMessage request)
        {
            Messages = messages;
            Request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, Messages);
        }
    }
}
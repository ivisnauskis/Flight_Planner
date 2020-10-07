using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Web.Models
{
    public class BadRequest : IHttpActionResult
    {
        public IEnumerable<string> Errors { get; private set; }
        public HttpRequestMessage Request { get; private set; }

        public BadRequest(IEnumerable<string> errors, HttpRequestMessage request)
        {
            Errors = errors;
            Request = request;
        }


        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, Errors);
        }
    }
}
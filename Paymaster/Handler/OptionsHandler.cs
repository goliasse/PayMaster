using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Paymaster.Handler
{
    /// <summary>
    /// Handles Option calls
    /// </summary>
    public class OptionsHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (!request.Method.Equals(HttpMethod.Options))
                return base.SendAsync(request, cancellationToken);

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace RS1_api_seminarski_proba.Helpers
{
    [ApiController]
    public abstract class MyBaseEndpoint<TRequest, TResponse> : ControllerBase
    {
        public abstract Task<ActionResult<TResponse>> Obradi(TRequest request, CancellationToken cancellationToken=default);
    }
}

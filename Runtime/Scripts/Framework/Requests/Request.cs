using System.Collections;
using System.Threading.Tasks;

using UnityEngine;

namespace HexUN.Framework.Request
{
    /// <summary>
    /// Implements a request object that requires a reponder to populate
    /// response.
    /// </summary>
    public class Request<TReq, TRes>
    {
        private readonly TaskCompletionSource<TRes> _src = new TaskCompletionSource<TRes>();

        /// <summary>
        /// Is the request complete
        /// </summary>
        public bool IsComplete { get; private set; }

        /// <summary>
        /// The object sent as the request
        /// </summary>
        public TReq RequestObject { get; private set; }

        /// <summary>
        /// The object sent in response
        /// </summary>
        public TRes ResponseObject { get; private set; }

        /// <summary>
        /// Creates a request by populating the request object ONLY
        /// </summary>
        public Request(TReq request) => RequestObject = request;

        /// <summary>
        /// Await the completion of the request
        /// </summary>
        public async Task<TRes> AwaitAsync() => await _src.Task;

        /// <summary>
        /// Awaits the completion of the request by checking that the task
        /// is completed. If it is not, wait one frame and tries again
        /// </summary>
        public IEnumerator AwaitCoroutine()
        {
            while (!IsComplete) yield return new WaitForEndOfFrame();
        }

        /// <summary>
        /// Complete the request by providing a response
        /// </summary>
        public void Respond(TRes Response)
        {
            if (IsComplete) return;

            ResponseObject = Response;
            _src.TrySetResult(Response);
        }
    }
}
using System;
using System.Collections;
using System.Threading.Tasks;
using System.Timers;

using UnityEngine;

namespace HexUN.Framework.Request
{
    /// <summary>
    /// Implements a request object that requires a reponder to populate
    /// response.
    /// </summary>
    public class Request<TReq, TRes>
    {
        private System.Timers.Timer aTimer;

        private readonly TaskCompletionSource<TRes> _src = new TaskCompletionSource<TRes>();

        private Coroutine _timeout;

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
        /// Await the completion of the request. Set timeout in milliseconds.
        /// Throws <see cref="TimeoutException"/> if timeout occurs
        /// </summary>
        public async Task<TRes> AwaitAsync(float timeout = 1000)
        {
            SetTimeoutTimer(timeout);
            return await _src.Task;
        }

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

        private void SetTimeoutTimer(float timeout)
        {
            aTimer = new Timer(timeout);
            aTimer.Elapsed += OnTimeout;
            aTimer.Enabled = true;

            void OnTimeout(System.Object source, ElapsedEventArgs e)
            {
                _src.SetException(new RequestException($"Request timed out after {timeout} milliseconds"));
                aTimer.Dispose();
                aTimer = null;
            }
        }

        public class RequestException : Exception 
        {
            public RequestException() : base() { }
            public RequestException(string message) : base(message) { }
        }
    }
}
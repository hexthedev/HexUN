using System.Collections.Generic;
using HexUN.MonoB;
using HexUN.Work;

namespace HexUN.Patterns
{
    /// <summary>
    /// Provides base class functionality for Controls in the Control
    /// View design pattern
    /// </summary>
    public class AControl : MonoDependent
    {
        private Dictionary<int, WorkToken> _workCache;

        private Dictionary<int, WorkToken> _work
        {
            get
            {
                if (_workCache == null) _workCache = new Dictionary<int, WorkToken>();
                return _workCache;
            }
        }

        /// <summary>
        /// Checks to see if work of id is complete
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        protected bool IsWorkIdle(int workId) => GetWorkToken(workId).GetWorkState() == EWorkState.Idle;

        /// <summary>
        /// Returns a cleared work token. If listeneres are still busy doing work for this token, 
        /// they are disregarded in sending new commands
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        protected WorkToken GetFreshWorkToken(int workId)
        {
            WorkToken tok = GetWorkToken(workId);
            tok.Clear();
            return tok;
        }

        /// <summary>
        /// Sends a command if all work on command stream is idle
        /// </summary>
        protected void SendCommandIfIdle(ref CVCommandReliableEvent cmd, int workId, object commandArg = null)
        {
            if (!IsWorkIdle(workId)) return;
            cmd.Invoke(new CVCommand(GetFreshWorkToken(workId), commandArg));
        }

        private WorkToken GetWorkToken(int workId)
        {
            if(!_work.TryGetValue(workId, out WorkToken tok))
            {
                tok = new WorkToken();
                _work[workId] = tok;
            }

            return tok;
        }
    }
}
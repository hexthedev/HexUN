using System;

namespace Hex.UN.Runtime.Framework.Data.Database
{
    public abstract class AGuidableData : IGuidable
    {
        protected Guid _guid;

        public Guid Guid => _guid;

        public AGuidableData()
        {
            _guid = Guid.NewGuid();
        }
    }
}

using System;

namespace Hex.UN.Runtime.Framework.Data.Database
{
    public interface IGuidable
    {
        /// <summary>
        /// The Guid id of the object 
        /// </summary>
        Guid Guid { get; }
    }
}

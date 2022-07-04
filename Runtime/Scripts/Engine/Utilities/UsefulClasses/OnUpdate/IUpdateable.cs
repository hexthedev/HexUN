using HexCS.Core;

namespace Hex.UN.Runtime.Engine.Utilities.UsefulClasses.OnUpdate
{
    public interface IUpdateable<T>
    {
        IEventSubscriber<T> OnUpdate { get; }
    }
}

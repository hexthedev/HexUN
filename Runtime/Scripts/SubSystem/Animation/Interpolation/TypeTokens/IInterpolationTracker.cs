using HexCS.Core;

namespace Hex.UN.Runtime.SubSystem.Animation.Interpolation.TypeTokens
{
    public interface IInterpolationTracker
    {
        /// <summary>
        /// Invoked when the interpolation ends naturally
        /// </summary>
        IEventSubscriber OnInterpolationEndSubscriber { get; }

        /// <summary>
        /// Invoked when the interpolation is canceled
        /// </summary>
        IEventSubscriber OnInterpolationCanceledSubscriber { get; }

        /// <summary>
        /// Cancels the interpolation
        /// </summary>
        void Cancel();
    }
}
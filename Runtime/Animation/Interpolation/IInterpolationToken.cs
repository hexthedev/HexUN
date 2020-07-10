using TobiasCSStandard.Core;

namespace HexUN.Animation
{
    /// <summary>
    /// Obtained by something performing requesting an interpolation. Can be used to subscribe
    /// to important interpolation events or cancel the interpolation
    /// </summary>
    public interface IInterpolationToken
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
        /// Invoked when an interpolation occur and returns the calculated interpolation value
        /// </summary>
        IEventSubscriber<float[]> OnInterpolationSubscriber { get; }

        /// <summary>
        /// Cancels the interpolation
        /// </summary>
        void Cancel();
    }
}
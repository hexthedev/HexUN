using HexCS.Core;
using UnityEngine;

namespace HexUN.Animation
{
    /// <summary>
    /// Provides events that follow the progress of a TransformInterpolation
    /// </summary>
    public interface IVector3InterpolationToken
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
        IEventSubscriber<Vector3> OnInterpolationSubscriber { get; }

        /// <summary>
        /// Cancels the interpolation
        /// </summary>
        void Cancel();
    }
}
using Hex.UN.Runtime.Engine.Math.Interpolation;

namespace Hex.UN.Runtime.SubSystem.Animation.Interpolation
{
    /// <summary>
    /// The core arguments that define an interpolation
    /// </summary>
    public struct SInterpolation
    {
        /// <summary>
        /// The start value of the interpolation
        /// </summary>
        public float Start;

        /// <summary>
        /// The end value of the interpolation
        /// </summary>
        public float End;

        /// <summary>
        /// The easing function used by the interpolation
        /// </summary>
        public EEasingFunction Ease;

        public SInterpolation(float start, float end, EEasingFunction ease)
        {
            Start = start;
            End = end;
            Ease = ease;
        }
    }
}
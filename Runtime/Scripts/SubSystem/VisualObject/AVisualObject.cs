using HexUN.MonoB;

namespace HexUN.Render
{
    /// <summary>
    /// Facade with functionality to call a render function every frame if
    /// some value has changed
    /// </summary>
    public abstract class AVisualObject : MonoData
    {
        /// <summary>
        /// set to true in order to cause handle render to be called this frame
        /// </summary>
        protected bool RenderThisFrame { get; set; }

        /// <summary>
        /// Handle the logic required when a render occurs
        /// </summary>
        protected abstract void HandleFrameRender();

        /// <summary>
        /// Initalization code for the ui element
        /// </summary>
        public virtual void Initialize()
        {
            Render();
        }

        /// <summary>
        /// Call to force a render to happen this frame. A render will do work to
        /// update a views visuals. 
        /// </summary>
        public void Render()
        {
            RenderThisFrame = true;
        }

        private void LateUpdate()
        {
            if (RenderThisFrame)
            {
                HandleFrameRender();
                RenderThisFrame = false;
            }
        }
    }
}

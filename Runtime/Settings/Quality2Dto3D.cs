using UnityEngine;
using UnityEngine.Rendering;

namespace Marmary.Utils.Runtime.Settings
{
    /// <summary>
    ///     Provides utilities for configuring quality settings when transitioning between
    ///     2D and 3D rendering in Unity projects.
    /// </summary>
    /// <remarks>
    ///     This class enables the adjustment of rendering quality by assigning a custom
    ///     RenderPipelineAsset to the QualitySettings render pipeline.
    /// </remarks>
    public class Quality2Dto3D : MonoBehaviour
    {
        #region Methods

        /// <summary>
        ///     Sets the current render pipeline for the application using the specified render pipeline asset.
        /// </summary>
        /// <param name="overrideRenderPipelineAsset">
        ///     The RenderPipelineAsset object to override the current render pipeline.
        ///     This parameter determines the visual quality and performance settings for rendering.
        /// </param>
        public static void SetQuality(RenderPipelineAsset overrideRenderPipelineAsset)
        {
            QualitySettings.renderPipeline = overrideRenderPipelineAsset;
        }

        #endregion
    }
}
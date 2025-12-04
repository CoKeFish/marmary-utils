using DTT.ExtendedDebugLogs;
using TheraBytes.BetterUi;
using UnityEngine;
using UnityEngine.UI;

namespace Marmary.Utils.Runtime.Settings
{
    /// <inheritdoc cref="UnityEngine.MonoBehaviour" />
    /// <summary>
    ///     This class ensures that the background sprite fits the screen dimensions.
    ///     This script adjusts the camera orthographic size to fit the background sprite
    ///     based on the screen width and height.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundFitControllerSpriteRenderer : MonoBehaviour, IResolutionDependency
    {
        #region Fields

        /// <summary>
        ///     Background height.
        /// </summary>
        private float _backgroundHeight;

        /// <summary>
        ///     Background width.
        /// </summary>
        private float _backgroundWidth;

        /// <summary>
        ///     Screen height.
        /// </summary>
        private int _screenHeight;

        /// <summary>
        ///     Screen width.
        /// </summary>
        private int _screenWidth;

        /// <summary>
        ///     Main camera.
        /// </summary>
        private Camera _mainCamera;

        /// <summary>
        ///     Image component (unused).
        /// </summary>
        private Image _image; // Variable sin uso actual

        /// <summary>
        ///     Sprite renderer component.
        /// </summary>
        private SpriteRenderer _spriteRenderer;

        #endregion

        #region Unity Event Functions

        /// <summary>
        ///     Start is called before the first frame update.
        ///     This method initializes the sprite renderer and calculates the dimensions
        ///     of the background sprite and screen. It adjusts the camera's orthographic
        ///     size based on these dimensions.
        /// </summary>
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (_spriteRenderer == null)
            {
                DebugEx.LogError("SpriteRenderer component is missing.", this, SettingTag.Screen);
                return;
            }

            _mainCamera = Camera.main;
            if (_mainCamera == null)
            {
                DebugEx.LogError("Main camera is missing.", this, SettingTag.Screen);
                return;
            }

            var bounds = _spriteRenderer.bounds.size;
            _backgroundWidth = bounds.x / 2;
            _backgroundHeight = bounds.y / 2;

            _screenWidth = Screen.width;
            _screenHeight = Screen.height;

            AdjustCameraSize();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Adjusts the camera's orthographic size to fit the background sprite.
        ///     This method calculates the aspect ratio and adjusts the orthographic size
        ///     of the main camera to ensure the background sprite fits the screen dimensions.
        /// </summary>
        private void AdjustCameraSize()
        {
            var aspectRatio = (float)Screen.width / Screen.height;
            DebugEx.Log("Screen width: " + Screen.width + " Screen height: " +
                        Screen.height, this, SettingTag.Screen);

            if (_backgroundWidth / aspectRatio < _backgroundHeight)
            {
                _mainCamera.orthographicSize = _backgroundWidth / aspectRatio;
                DebugEx.Log("Background width: " + _backgroundWidth + " Background height: " + _backgroundHeight, this,
                    SettingTag.Screen);
                DebugEx.Log("Adjusted for wider aspect ratio", this, SettingTag.Screen);
            }
            else
            {
                _mainCamera.orthographicSize = _backgroundHeight;
                DebugEx.Log("Adjusted for taller aspect ratio", this, SettingTag.Screen);
            }
        }

        #endregion

        #region IResolutionDependency Members

        /// <summary>
        ///     Called when the screen resolution changes.
        ///     This method adjusts the camera's orthographic size when the screen resolution changes.
        /// </summary>
        public void OnResolutionChanged()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) return;
#endif
            if (_screenWidth == Screen.width && _screenHeight == Screen.height) return;

            AdjustCameraSize();

            // Update stored screen dimensions
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;
        }

        #endregion
    }
}
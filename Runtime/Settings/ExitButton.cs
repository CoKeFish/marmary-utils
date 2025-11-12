using UnityEngine;
using UnityEngine.UI;

namespace Marmary.Libraries.Settings
{
    /// <summary>
    /// Represents a UI button designed to trigger the application's exit functionality.
    /// Typically used in game or application menus to provide users with the option to close the application.
    /// </summary>
    public class ExitButton : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Represents the button component attached to the ExitButton, facilitating the setup
        /// and handling of user interaction events such as triggering the exit functionality
        /// when clicked.
        /// </summary>
        private Button _button;

        #endregion

        #region Unity Event Functions

        /// <summary>
        /// Initializes the ExitButton component by setting up the button's click event listener.
        /// This method is automatically called by Unity when the script is enabled and active in the scene.
        /// </summary>
        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        #endregion

        #region Event Functions

        /// <summary>
        /// Handles the button's click event by quitting the application.
        /// This method is invoked when the ExitButton component's click event is triggered.
        /// </summary>
        private void OnClick()
        {
            Application.Quit();
        }

        #endregion
    }
}
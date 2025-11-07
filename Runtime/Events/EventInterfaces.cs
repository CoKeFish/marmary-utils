using UnityEngine.EventSystems;

namespace Marmary.Libraries.UI.Events
{
    /// <summary>
    ///     IPressedHandler is an interface that is used by the UI system to send events when a UI element is pressed.
    /// </summary>
    public interface IPressedHandler : IEventSystemHandler
    {
        #region Event Functions

        /// <summary>
        /// Called when a UI element is pressed.
        /// </summary>
        /// <param name="eventData">The event data associated with the pointer press event.</param>
        void OnPressed(PointerEventData eventData);

        #endregion
    }

    /// <summary>
    /// IUnPressedHandler is an interface that is used by the UI system to send events when a UI element is unpressed.
    /// </summary>
    public interface IUnPressedHandler : IEventSystemHandler
    {
        #region Event Functions

        /// <summary>
        /// Invoked when a UI element is unpressed, providing event data containing details of the pointer interaction.
        /// </summary>
        /// <param name="eventData">
        /// The event data associated with the unpress action, including details such as pointer position, clicked object, and interaction states.
        /// </param>
        void OnUnPressed(PointerEventData eventData);

        #endregion
    }
}
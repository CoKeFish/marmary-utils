using UnityEngine.EventSystems;
using UExecuteEvents = UnityEngine.EventSystems.ExecuteEvents; // Alias

namespace Marmary.Utils.Runtime.Events
{
    /// <summary>
    ///     This class is used to call the events of the interfaces.
    /// </summary>
    public static class MExecuteEvents
    {
        #region Properties

        /// <summary>
        ///     This is the event function for the IPressedHandler interface.
        /// </summary>
        public static UExecuteEvents.EventFunction<IPressedHandler> PressedHandler { get; } = Execute;

        /// <summary>
        ///     This is the event function for the IUnPressedHandler interface.
        /// </summary>
        public static UExecuteEvents.EventFunction<IUnPressedHandler> UnpressedHandler { get; } = Execute;

        #endregion

        #region Methods

        /// <summary>
        ///     This method is used to call the OnPressed method of the IPressedHandler interface.
        /// </summary>
        /// <param name="handler"> is the handler of the interface. </param>
        /// <param name="eventData"> is the event data of the interface. </param>
        private static void Execute(IPressedHandler handler, BaseEventData eventData)
        {
            handler.OnPressed(UExecuteEvents.ValidateEventData<PointerEventData>(eventData));
        }

        /// <summary>
        ///     This method is used to call the OnUnPressed method of the IUnPressedHandler interface.
        /// </summary>
        /// <param name="handler"> is the handler of the interface. </param>
        /// <param name="eventData"> is the event data of the interface. </param>
        private static void Execute(IUnPressedHandler handler, BaseEventData eventData)
        {
            handler.OnUnPressed(UExecuteEvents.ValidateEventData<PointerEventData>(eventData));
        }

        #endregion
    }
}
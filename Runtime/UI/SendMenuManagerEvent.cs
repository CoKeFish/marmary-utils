namespace Marmary.Utils.Runtime.UI
{
    /// <summary>
    /// Represents an event that is sent to manage a menu by providing an implementation
    /// of the <see cref="IDefaultSelectable"/> interface.
    /// </summary>
    public readonly struct SendMenuManagerEvent
    {
        /// <summary>
        /// Represents a reference to an instance of <see cref="IDefaultSelectable"/>
        /// that allows configuration of default selectable UI elements based on position.
        /// </summary>
        public readonly IDefaultSelectable MenuManager;


        /// <summary>
        /// Represents an event for the menu manager that is associated with a specific
        /// implementation of <see cref="IDefaultSelectable"/>.
        /// This struct is used to encapsulate the behavior or state required to handle
        /// a menu management operation.
        /// </summary>
        public SendMenuManagerEvent(IDefaultSelectable menuManager)
        {
            MenuManager = menuManager;
        }
    }

}
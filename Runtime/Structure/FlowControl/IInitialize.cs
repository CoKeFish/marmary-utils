namespace Marmary.Utils.Runtime.Structure.FlowControl
{
    /// <summary>
    /// Represents a contract for objects that require initialization logic.
    /// </summary>
    public interface IInitialize
    {
        /// <summary>
        /// Prepares or sets up necessary resources, settings, or operations
        /// required before the system or component is fully functional.
        /// </summary>
        /// <remarks>This method is called once during the lifetime of the object.</remarks>
        void Initialize();
    }
}
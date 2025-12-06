namespace Marmary.Utils.Runtime.Structure.FlowControl
{
    /// <summary>
    /// Represents a contract for initializing or configuring a specific component, service, or process.
    /// Implementations of this interface provide setup logic, often executed
    /// during the initialization phase of an application or system.
    /// </summary>
    public interface ISetup
    {
        /// <summary>
        /// Configures and initializes the required components for the implementation.
        /// It is intended to establish the initial state or configuration needed
        /// for the successful execution of subsequent operations.
        /// </summary>
        /// <remarks>This method is called several times during the lifetime of the object.</remarks>
        void Setup();
    }
}
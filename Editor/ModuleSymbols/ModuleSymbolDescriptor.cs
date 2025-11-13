#if UNITY_EDITOR

namespace Marmary.Utils.Editor.ModuleSymbols

{
    /// <summary>
    ///     Describes a module and the symbols that enable it through conditional compilation.
    /// </summary>
    /// <remarks>
    ///     Descriptors are registered in <see cref="ModuleSymbolRegistry" /> and exposed in the configuration window
    ///     to toggle features on and off.
    /// </remarks>
    public class ModuleSymbolDescriptor

    {
        #region Fields

        /// <summary>
        ///     Friendly module name shown in the window.
        /// </summary>
        public string ModuleName;

        /// <summary>
        ///     Symbol options available for this module.
        /// </summary>
        public SymbolOption[] Options;

        #endregion
    }
}

#endif
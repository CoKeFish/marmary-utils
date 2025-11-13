#if UNITY_EDITOR

using System;

namespace Marmary.Utils.Editor.ModuleSymbols

{
    /// <summary>
    ///     Represents a specific symbol that can be toggled from the editor.
    /// </summary>
    [Serializable]
    public class SymbolOption

    {
        #region Serialized Fields

        /// <summary>
        ///     Exact name of the scripting define symbol.
        /// </summary>
        public string symbol;

        /// <summary>
        ///     Description displayed as tooltip in the interface.
        /// </summary>
        public string description;

        /// <summary>
        ///     Indicates whether the symbol starts enabled the first time the system runs.
        /// </summary>
        public bool enabledByDefault;

        #endregion
    }
}

#endif
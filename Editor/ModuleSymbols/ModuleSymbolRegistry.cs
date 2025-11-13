#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;

namespace Marmary.Utils.Editor.ModuleSymbols

{
    /// <summary>
    ///     Global registry of module symbol descriptors available inside the editor.
    /// </summary>
    /// <remarks>
    ///     Initialized automatically on load and keeps a single list of every <see cref="ModuleSymbolDescriptor" />
    ///     declared by the different modules in the project.
    /// </remarks>
    [InitializeOnLoad]
    public static class ModuleSymbolRegistry

    {
        /// <summary>
        ///     Internal list with all registered descriptors.
        /// </summary>
        private static readonly List<ModuleSymbolDescriptor> _descriptors = new();

        #region Properties

        /// <summary>
        ///     Returns every descriptor currently registered.
        /// </summary>
        public static IEnumerable<ModuleSymbolDescriptor> Descriptors => _descriptors;

        #endregion

        #region Constructors and Injected

        static ModuleSymbolRegistry()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds the descriptor to the registry if it is not already present.
        /// </summary>
        /// <param name="desc">Descriptor provided by a module.</param>
        public static void Register(ModuleSymbolDescriptor desc)

        {
            if (!_descriptors.Contains(desc))

                _descriptors.Add(desc);
        }

        #endregion
    }
}

#endif
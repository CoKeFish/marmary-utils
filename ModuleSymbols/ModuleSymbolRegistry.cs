#if UNITY_EDITOR

using UnityEditor;

using System.Collections.Generic;

namespace MyCompany.ModuleSymbols

{

    // Registro global

    [InitializeOnLoad]

    public static class ModuleSymbolRegistry

    {

        static List<ModuleSymbolDescriptor> _descriptors = new List<ModuleSymbolDescriptor>();

        public static IReadOnlyList<ModuleSymbolDescriptor> Descriptors => _descriptors;

        public static void Register(ModuleSymbolDescriptor desc)

        {

            if (!_descriptors.Contains(desc))

                _descriptors.Add(desc);

        }

    }

}

#endif



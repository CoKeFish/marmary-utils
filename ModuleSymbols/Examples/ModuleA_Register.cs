#if UNITY_EDITOR

using UnityEditor;

using MyCompany.ModuleSymbols;

namespace MyCompany.ModuleSymbols.Examples

{

    // Ejemplo de módulo registrando sus símbolos
    // Este registro solo se ejecutará si MODULE_A está definido

#if MODULE_A

    [InitializeOnLoad]

    public static class ModuleA_Register

    {

        static ModuleA_Register()

        {

            var desc = new ModuleSymbolDescriptor

            {

                moduleName = "Module A",

                options = new SymbolOption[]

                {

                    new SymbolOption { symbol = "MODULE_A_FEATURE_X", description = "Habilita feature X del módulo A", enabledByDefault = false },

                    new SymbolOption { symbol = "MODULE_A_DEBUG", description = "Debug interno módulo A", enabledByDefault = false }

                }

            };

            ModuleSymbolRegistry.Register(desc);

        }

    }

#endif

}

#endif


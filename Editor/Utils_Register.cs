#if UNITY_EDITOR

using Marmary.Utils.Editor.ModuleSymbols;
using UnityEditor;

namespace Marmary.Utils

{

    // Registro de símbolos para Utils
    // Este registro solo se ejecutará si MODULE_SYMBOLS_SYSTEM_ENABLED está definido

#if MODULE_SYMBOLS_SYSTEM_ENABLED

    [InitializeOnLoad]

    public static class Utils_Register

    {

        static Utils_Register()

        {

            var desc = new ModuleSymbolDescriptor

            {

                ModuleName = "Utils",

                Options = new SymbolOption[]

                {

                    new SymbolOption { symbol = "STATE_MACHINE_BASE_ENABLED", description = "Habilita StateMachineBase para máquinas de estado con Stateless", enabledByDefault = false }

                }

            };

            ModuleSymbolRegistry.Register(desc);

        }

    }

#endif

}

#endif


#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

namespace Marmary.Utils.Editor.ModuleSymbols

{
    /// <summary>
    ///     Editor window that lists module symbols and lets the user toggle them.
    /// </summary>
    public class ModuleSymbolsWindow : EditorWindow

    {
        #region Fields

        /// <summary>
        ///     Scroll position used by the scroll view.
        /// </summary>
        private Vector2 _scroll;

        /// <summary>
        ///     Current state for every symbol, indexed by symbol name.
        /// </summary>
        private readonly Dictionary<string, bool> _state = new();

        #endregion

        #region Unity Event Functions

        /// <summary>
        ///     Initializes the window by loading registered symbols and their persisted state.
        /// </summary>
        private void OnEnable()

        {
            // Asegurar que MODULE_SYMBOLS_SYSTEM_ENABLED esté definido por defecto
            EnsureDefaultSymbol();

            // inicializar estados

            foreach (var desc in ModuleSymbolRegistry.Descriptors)

            foreach (var opt in desc.Options)

                _state[opt.symbol] = EditorPrefs.GetBool("SYM_" + opt.symbol, opt.enabledByDefault);
        }

        /// <summary>
        ///     Renders the interface and handles user interaction.
        /// </summary>
        private void OnGUI()

        {
            _scroll = EditorGUILayout.BeginScrollView(_scroll);

            foreach (var desc in ModuleSymbolRegistry.Descriptors)

            {
                EditorGUILayout.LabelField(desc.ModuleName, EditorStyles.boldLabel);

                foreach (var opt in desc.Options)

                {
                    var cur = _state[opt.symbol];

                    var next = EditorGUILayout.Toggle(new GUIContent(opt.symbol, opt.description), cur);

                    if (next != cur)

                    {
                        _state[opt.symbol] = next;

                        EditorPrefs.SetBool("SYM_" + opt.symbol, next);
                    }
                }

                EditorGUILayout.Space();
            }

            EditorGUILayout.EndScrollView();

            if (GUILayout.Button("Apply Symbols")) ApplySymbols();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Opens the module symbols manager window.
        /// </summary>
        [MenuItem("Tools/Module Symbols Manager")]
        public static void ShowWindow()

        {
            GetWindow<ModuleSymbolsWindow>("Module Symbols");
        }

        /// <summary>
        ///     Makes sure the system base symbol is present in the global scripting define symbols.
        /// </summary>
        private void EnsureDefaultSymbol()

        {
            const string defaultSymbol = "MODULE_SYMBOLS_SYSTEM_ENABLED";

#if UNITY_2021_2_OR_NEWER
            var buildTarget = NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            var defines = PlayerSettings.GetScriptingDefineSymbols(buildTarget);
#else
            var group = EditorUserBuildSettings.selectedBuildTargetGroup;
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(group);
#endif

            var list = new HashSet<string>(defines.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));

            if (!list.Contains(defaultSymbol))

            {
                list.Add(defaultSymbol);

                var newDefines = string.Join(";", list);

#if UNITY_2021_2_OR_NEWER
                PlayerSettings.SetScriptingDefineSymbols(buildTarget, newDefines);
#else
                PlayerSettings.SetScriptingDefineSymbolsForGroup(group, newDefines);
#endif
            }
        }

        /// <summary>
        ///     Applies the selected symbols to the active build target group.
        /// </summary>
        private void ApplySymbols()

        {
#if UNITY_2021_2_OR_NEWER
            var buildTarget = NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            var defines = PlayerSettings.GetScriptingDefineSymbols(buildTarget);
#else
            var group = EditorUserBuildSettings.selectedBuildTargetGroup;
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(group);
#endif

            var list = new HashSet<string>(defines.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));

            // Agregar símbolo por defecto del sistema
            const string defaultSymbol = "MODULE_SYMBOLS_SYSTEM_ENABLED";
            list.Add(defaultSymbol);

            foreach (var kv in _state)

                if (kv.Value)

                    list.Add(kv.Key);

                else

                    list.Remove(kv.Key);

            var newDefines = string.Join(";", list);

#if UNITY_2021_2_OR_NEWER
            PlayerSettings.SetScriptingDefineSymbols(buildTarget, newDefines);
#else
            PlayerSettings.SetScriptingDefineSymbolsForGroup(group, newDefines);
#endif

            Debug.Log("Updated scripting define symbols: " + newDefines);

            // Nota: Unity requiere recompilar scripts para aplicar cambios.
        }

        #endregion
    }
}

#endif
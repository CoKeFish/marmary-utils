#if UNITY_EDITOR

using UnityEditor;

using UnityEngine;

using System;

using System.Collections.Generic;

#if UNITY_2021_2_OR_NEWER
using UnityEditor.Build;
#endif

namespace MyCompany.ModuleSymbols

{

    // Ventana del editor

    public class ModuleSymbolsWindow : EditorWindow

    {

        Vector2 _scroll;

        Dictionary<string,bool> _state = new Dictionary<string,bool>();

        [MenuItem("Tools/Module Symbols Manager")]

        public static void ShowWindow()

        {

            GetWindow<ModuleSymbolsWindow>("Module Symbols");

        }

        void OnEnable()

        {

            // Asegurar que MODULE_SYMBOLS_SYSTEM_ENABLED esté definido por defecto
            EnsureDefaultSymbol();

            // inicializar estados

            foreach (var desc in ModuleSymbolRegistry.Descriptors)

            {

                foreach (var opt in desc.options)

                {

                    _state[opt.symbol] = EditorPrefs.GetBool("SYM_"+opt.symbol, opt.enabledByDefault);

                }

            }

        }

        void EnsureDefaultSymbol()

        {

            const string DEFAULT_SYMBOL = "MODULE_SYMBOLS_SYSTEM_ENABLED";

#if UNITY_2021_2_OR_NEWER
            var buildTarget = NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            string defines = PlayerSettings.GetScriptingDefineSymbols(buildTarget);
#else
            var group = EditorUserBuildSettings.selectedBuildTargetGroup;
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(group);
#endif

            var list = new HashSet<string>(defines.Split(new[]{';'}, StringSplitOptions.RemoveEmptyEntries));

            if (!list.Contains(DEFAULT_SYMBOL))

            {

                list.Add(DEFAULT_SYMBOL);

                string newDefines = string.Join(";", list);

#if UNITY_2021_2_OR_NEWER
                PlayerSettings.SetScriptingDefineSymbols(buildTarget, newDefines);
#else
                PlayerSettings.SetScriptingDefineSymbolsForGroup(group, newDefines);
#endif

            }

        }

        void OnGUI()

        {

            _scroll = EditorGUILayout.BeginScrollView(_scroll);

            foreach (var desc in ModuleSymbolRegistry.Descriptors)

            {

                EditorGUILayout.LabelField(desc.moduleName, EditorStyles.boldLabel);

                foreach (var opt in desc.options)

                {

                    bool cur = _state[opt.symbol];

                    bool next = EditorGUILayout.Toggle(new GUIContent(opt.symbol, opt.description), cur);

                    if (next != cur)

                    {

                        _state[opt.symbol] = next;

                        EditorPrefs.SetBool("SYM_"+opt.symbol, next);

                    }

                }

                EditorGUILayout.Space();

            }

            EditorGUILayout.EndScrollView();

            if (GUILayout.Button("Apply Symbols"))

            {

                ApplySymbols();

            }

        }

        void ApplySymbols()

        {

#if UNITY_2021_2_OR_NEWER
            var buildTarget = NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            string defines = PlayerSettings.GetScriptingDefineSymbols(buildTarget);
#else
            var group = EditorUserBuildSettings.selectedBuildTargetGroup;
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(group);
#endif

            var list = new HashSet<string>(defines.Split(new[]{';'}, StringSplitOptions.RemoveEmptyEntries));

            // Agregar símbolo por defecto del sistema
            const string DEFAULT_SYMBOL = "MODULE_SYMBOLS_SYSTEM_ENABLED";
            list.Add(DEFAULT_SYMBOL);

            foreach (var kv in _state)

            {

                if (kv.Value)

                    list.Add(kv.Key);

                else

                    list.Remove(kv.Key);

            }

            string newDefines = string.Join(";", list);

#if UNITY_2021_2_OR_NEWER
            PlayerSettings.SetScriptingDefineSymbols(buildTarget, newDefines);
#else
            PlayerSettings.SetScriptingDefineSymbolsForGroup(group, newDefines);
#endif

            Debug.Log("Updated scripting define symbols: " + newDefines);

            // Nota: Unity requiere recompilar scripts para aplicar cambios.

        }

    }

}

#endif


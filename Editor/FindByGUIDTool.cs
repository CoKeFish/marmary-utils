using UnityEditor;
using UnityEngine;

namespace Marmary.Utils.Editor
{
    /// <summary>
    /// Provides a utility for finding assets in a Unity project by their GUID.
    /// </summary>
    /// <remarks>
    /// The tool retrieves the GUID currently stored in the clipboard and attempts to locate
    /// the corresponding asset in the project's AssetDatabase. If an asset is found, it is
    /// selected in the Unity Editor and its path is logged. If no asset is found, an error
    /// message is logged.
    /// </remarks>
    /// <example>
    /// This tool can be used by copying the GUID of an asset to the system clipboard,
    /// then clicking on the "Find Asset By GUID" menu entry under the "Tools" menu
    /// in the Unity Editor.
    /// </example>
    /// <seealso cref="UnityEditor.EditorGUIUtility.systemCopyBuffer"/>
    /// <seealso cref="UnityEditor.AssetDatabase.GUIDToAssetPath(string)"/>
    /// <seealso cref="UnityEditor.AssetDatabase.LoadAssetAtPath{T}(string)"/>
    public static class FindByGuidTool
    {
        /// <summary>
        /// Finds and selects an asset in the Unity Editor based on the GUID currently stored in the clipboard.
        /// </summary>
        /// <remarks>
        /// This method retrieves the GUID from the system clipboard, converts it into an asset path
        /// using the Unity AssetDatabase, and then loads and selects the asset in the Unity Editor.
        /// If the GUID is invalid or no corresponding asset is found, an error message is logged.
        /// </remarks>
        /// <exception cref="UnityEditor.AssetDatabase">Error message logged if no asset is found for the provided GUID.</exception>
        /// <seealso cref="UnityEditor.EditorGUIUtility.systemCopyBuffer"/>
        /// <seealso cref="UnityEditor.AssetDatabase.GUIDToAssetPath(string)"/>
        /// <seealso cref="UnityEditor.AssetDatabase.LoadAssetAtPath{T}(string)"/>
        [MenuItem("Tools/Find Asset By GUID")]
        public static void Find()
        {
            string guid = EditorGUIUtility.systemCopyBuffer; // GUID copiado al portapapeles
            string path = AssetDatabase.GUIDToAssetPath(guid);

            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError("GUID no encontrado: " + guid);
                return;
            }

            Debug.Log("Asset encontrado: " + path);
            Selection.activeObject = AssetDatabase.LoadAssetAtPath<Object>(path);
        }
    }
}
namespace Marmary.Utils.Runtime.Extention.Odin
{
#if UNITY_EDITOR
    using Sirenix.OdinInspector.Editor;
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// Custom drawer for the <see cref="UniformVector3Attribute"/> class, used to enhance the editor UI
    /// for Vector3 properties in Unity when using the Odin Inspector framework.
    /// </summary>
    /// <remarks>
    /// This drawer enables a toggle-driven uniform modification behavior for Vector3 fields. When the toggle
    /// is enabled, changing one component of the vector (x, y, or z) will update the other two components
    /// to maintain a uniform value. This is helpful for scenarios where uniform scaling or other uniform
    /// vector values are required.
    /// </remarks>
    public class UniformVector3AttributeDrawer : OdinAttributeDrawer<UniformVector3Attribute, Vector3>
    {
        /// <summary>
        /// Indicates whether the uniform modification behavior is currently enabled in the custom drawer for
        /// <see cref="UniformVector3Attribute"/>.
        /// </summary>
        /// <remarks>
        /// When set to true, any change to one component of a Vector3 (x, y, or z) will automatically update
        /// the other components to maintain a uniform value. When set to false, components can be modified
        /// independently.
        /// </remarks>
        private bool _enabled;

        /// <summary>
        /// Initializes the custom drawer for the <see cref="UniformVector3Attribute"/>.
        /// </summary>
        /// <remarks>
        /// This method is executed once when the drawer is instantiated. It sets the initial state,
        /// such as whether the uniform modification behavior is enabled or disabled by default.
        /// </remarks>
        protected override void Initialize()
        {
            _enabled = Attribute.EnabledByDefault;
        }

        /// <summary>
        /// Draws the property layout for the Vector3 field with the <see cref="UniformVector3Attribute"/> applied.
        /// </summary>
        /// <param name="label">
        /// The label associated with the property being drawn in the editor.
        /// </param>
        /// <remarks>
        /// This method renders a custom UI for Vector3 fields in the Unity Editor using Odin Inspector.
        /// It includes a toggle that, when enabled, allows modification of the vector's components uniformly.
        /// If the toggle is activated and one component is changed, the other components are updated to match.
        /// </remarks>
        protected override void DrawPropertyLayout(GUIContent label)
        {
            EditorGUILayout.BeginHorizontal();

            // Toggle manual
            _enabled = GUILayout.Toggle(_enabled, GUIContent.none, GUILayout.Width(20));

            EditorGUI.BeginChangeCheck();
            Vector3 newValue = EditorGUILayout.Vector3Field(label, this.ValueEntry.SmartValue);

            if (EditorGUI.EndChangeCheck())
            {
                Vector3 oldValue = this.ValueEntry.SmartValue;

                if (_enabled)
                {
                    if (!Mathf.Approximately(newValue.x, oldValue.x))
                    {
                        newValue.y = newValue.x;
                        newValue.z = newValue.x;
                    }
                    else if (!Mathf.Approximately(newValue.y, oldValue.y))
                    {
                        newValue.x = newValue.y;
                        newValue.z = newValue.y;
                    }
                    else if (!Mathf.Approximately(newValue.z, oldValue.z))
                    {
                        newValue.x = newValue.z;
                        newValue.y = newValue.z;
                    }
                }

                this.ValueEntry.SmartValue = newValue;
            }

            EditorGUILayout.EndHorizontal();
        }
    }
#endif

}
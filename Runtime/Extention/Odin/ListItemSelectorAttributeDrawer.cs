#if UNITY_EDITOR

using System;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Marmary.Libraries.Extention.Odin
{
    /// <summary>
    ///     Custom drawer for the <see cref="ListItemSelectorAttribute" />.
    ///     Handles the selection of list items in the Unity Inspector with visual feedback.
    /// </summary>
    [DrawerPriority(0.01)]
    public class ListItemSelectorAttributeDrawer : OdinAttributeDrawer<ListItemSelectorAttribute>
    {
        /// <summary>
        ///     The color used to highlight the selected list item.
        /// </summary>
        private static readonly Color SelectedColor = new(0.301f, 0.563f, 1f, 0.497f);

        #region Fields

        /// <summary>
        ///     Action to set the selected index of the list.
        /// </summary>
        private Action<object, int> _selectedIndexSetter;

        /// <summary>
        ///     Indicates whether the current property is a list element.
        /// </summary>
        private bool _isListElement;

        /// <summary>
        ///     The base member property of the list.
        /// </summary>
        private InspectorProperty _baseMemberProperty;

        /// <summary>
        ///     The currently selected property.
        /// </summary>
        private InspectorProperty _selectedProperty;

        /// <summary>
        ///     Context for globally tracking the selected property.
        /// </summary>
        private PropertyContext<InspectorProperty> _globalSelectedProperty;

        #endregion

        #region Methods

        /// <summary>
        ///     Initializes the drawer and sets up the necessary context for handling list item selection.
        /// </summary>
        protected override void Initialize()
        {
            _isListElement = Property.Parent != null && Property.Parent.ChildResolver is IOrderedCollectionResolver;
            var isList = !_isListElement;
            var listProperty = isList ? Property : Property.Parent;
            if (listProperty != null)
                _baseMemberProperty = listProperty.FindParent(x => x.Info.PropertyType == PropertyType.Value, true);
            _globalSelectedProperty =
                _baseMemberProperty.Context.GetGlobal("selectedIndex" + _baseMemberProperty.GetHashCode(),
                    (InspectorProperty)null);

            if (isList)
            {
                var parentType = _baseMemberProperty.ParentValues[0].GetType();
                _selectedIndexSetter =
                    EmitUtilities.CreateWeakInstanceMethodCaller<int>(parentType.GetMethod(Attribute.SetSelectedMethod,
                        Flags.AllMembers));
            }
        }

        /// <summary>
        ///     Draws the property layout in the Unity Inspector, handling selection and visual feedback.
        /// </summary>
        /// <param name="label">The label of the property.</param>
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var t = Event.current.type;

            if (_isListElement)
            {
                if (t == EventType.Layout)
                {
                    CallNextDrawer(label);
                }
                else
                {
                    var rect = GUIHelper.GetCurrentLayoutRect();
                    var isSelected = _globalSelectedProperty.Value == Property;

                    if (t == EventType.Repaint && isSelected)
                        EditorGUI.DrawRect(rect, SelectedColor);
                    else if (t == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
                        _globalSelectedProperty.Value = Property;

                    CallNextDrawer(label);
                }
            }
            else
            {
                CallNextDrawer(label);

                if (Event.current.type != EventType.Layout)
                {
                    var sel = _globalSelectedProperty.Value;

                    // Select
                    if (sel != null && sel != _selectedProperty)
                    {
                        _selectedProperty = sel;
                        Select(_selectedProperty.Index);
                    }
                    // Deselect when destroyed
                    else if (_selectedProperty != null && _selectedProperty.Index < Property.Children.Count &&
                             _selectedProperty != Property.Children[_selectedProperty.Index])
                    {
                        var index = -1;
                        Select(index);
                        _selectedProperty = null;
                        _globalSelectedProperty.Value = null;
                    }
                }
            }
        }

        /// <summary>
        ///     Sets the selected index of the list and triggers a repaint of the Unity Inspector.
        /// </summary>
        /// <param name="index">The index of the selected item.</param>
        private void Select(int index)
        {
            GUIHelper.RequestRepaint();
            Property.Tree.DelayAction(() =>
            {
                for (var i = 0; i < _baseMemberProperty.ParentValues.Count; i++)
                    _selectedIndexSetter(_baseMemberProperty.ParentValues[i], index);
            });
        }

        #endregion
    }
}


#endif
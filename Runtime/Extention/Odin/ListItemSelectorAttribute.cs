using System;

namespace Marmary.Libraries.Extention.Odin
{
    /// <summary>
    ///     Attribute used to mark a method for selecting a list item.
    /// </summary>
    public class ListItemSelectorAttribute : Attribute
    {
        #region Fields

        /// <summary>
        ///     The name of the method that sets the selected item.
        /// </summary>
        public readonly string SetSelectedMethod;

        #endregion

        #region Constructors and Injected

        /// <summary>
        ///     Initializes a new instance of the <see cref="ListItemSelectorAttribute" /> class.
        /// </summary>
        /// <param name="setSelectedMethod">The name of the method that sets the selected item.</param>
        public ListItemSelectorAttribute(string setSelectedMethod)
        {
            SetSelectedMethod = setSelectedMethod;
        }

        #endregion
    }
}
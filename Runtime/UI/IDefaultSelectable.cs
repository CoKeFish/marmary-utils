namespace Marmary.Utils.Runtime
{
    /// <summary>
    ///     Defines a contract for an object that can set a default selectable element
    ///     based on a specified position.
    /// </summary>
    public interface IDefaultSelectable
    {
        #region Methods

        /// <summary>
        ///     Sets the default selectable UI element based on the specified position.
        /// </summary>
        /// <param name="position">
        ///     The position that determines the default selectable element. Possible values are Top, Bottom,
        ///     Left, and Right.
        /// </param>
        void SetDefaultSelectable(Position position);

        #endregion
    }
}
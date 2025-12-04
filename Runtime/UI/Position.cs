using System;

#if STATE_BEHAVIOR_ENABLED
namespace Marmary.Utils.Runtime
{
    /// <summary>
    ///     Represents the position to the right where an element can be hidden.
    /// </summary>
    [Serializable]
    public enum Position
    {
        /// <summary>
        ///     Specifies the top position within the enum, indicating that the element should be hidden at the top of the screen.
        /// </summary>
        Top,

        /// <summary>
        ///     Represents the bottom position where an element can be hidden.
        /// </summary>
        Bottom,

        /// <summary>
        ///     Specifies the 'Left' position, representing the element being hidden to the left side of the screen.
        /// </summary>
        Left,

        /// <summary>
        ///     Specifies the right position within the enum, indicating that the element should be hidden at the right of the
        ///     screen.
        /// </summary>
        Right
    }
}
#endif
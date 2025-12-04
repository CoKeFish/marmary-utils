namespace Marmary.Utils.Runtime.Extention.Odin
{
    using System;

    /// <summary>
    /// Attribute used to enforce or enable a uniform behavior for <see cref="UnityEngine.Vector3"/> properties.
    /// </summary>
    /// <remarks>
    /// When applied to a Vector3 field, this attribute enables a mode where all three components (x, y, and z)
    /// of the vector are modified uniformly when any one of them is changed. This is especially useful for cases
    /// where maintaining uniformity across the Vector3 components is required, such as uniform scaling.
    /// </remarks>
    public class UniformVector3Attribute : Attribute
    {
        /// <summary>
        /// Specifies whether the property or behavior associated with the
        /// <see cref="UniformVector3Attribute"/> is enabled by default.
        /// </summary>
        /// <remarks>
        /// When true, the uniform behavior applies automatically without requiring explicit activation.
        /// This is typically used to control the initial state of the attribute during runtime or in editors.
        /// </remarks>
        public bool EnabledByDefault;

        /// <summary>
        /// Custom attribute used to indicate a Vector3 property should have uniform values for its components.
        /// This attribute can enforce consistency in Vector3 values where required by design or application logic.
        /// </summary>
        public UniformVector3Attribute(bool enabledByDefault = true)
        {
            EnabledByDefault = enabledByDefault;
        }
    }


}
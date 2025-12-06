using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Marmary.Utils.Runtime.Structure
{
    /// <summary>
    ///     A static instance of a MonoBehaviour is similar to a singleton, but instead
    ///     of destroying any instance that already exists, it will override it.
    /// </summary>
    /// <typeparam name="T">Type of the MonoBehaviour.</typeparam>
    [IgnoreUnityLifecycle]
    public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Properties

        /// <summary>
        ///     Gets the instance of the MonoBehaviour.
        /// </summary>
        public static T Instance { get; private set; }

        #endregion

        #region Unity Event Functions

        /// <summary>
        ///     Called when the script instance is being loaded.
        ///     Sets the instance to this object.
        /// </summary>
        protected virtual void Awake()
        {
            Instance = this as T;
        }

        /// <summary>
        ///     Called when the application is quitting.
        ///     Resets the instance and destroys the game object.
        /// </summary>
        protected void OnApplicationQuit()
        {
            Instance = null;
            Destroy(gameObject);
        }

        #endregion
    }

    /// <summary>
    ///     Transforms the static instance into a basic singleton.
    ///     This will destroy any instance that already exists, leaving the
    ///     original instance intact.
    /// </summary>
    /// <typeparam name="T">Type of the MonoBehaviour.</typeparam>
    public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
    {
        #region Unity Event Functions

        /// <summary>
        ///     Called when the script instance is being loaded.
        ///     Destroys the game object if an instance already exists.
        /// </summary>
        protected override void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            base.Awake();
        }

        #endregion
    }

    /// <summary>
    ///     A singleton that will persist through scene changes.
    /// </summary>
    /// <typeparam name="T">Type of the MonoBehaviour.</typeparam>
    public abstract class SingletonPersistent<T> : Singleton<T> where T : MonoBehaviour
    {
        #region Unity Event Functions

        /// <summary>
        ///     Called when the script instance is being loaded.
        ///     Marks the game object to not be destroyed on scene load.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        #endregion
    }

    /// <summary>
    /// Provides a base class for implementing singleton pattern with ScriptableObjects,
    /// ensuring a single instance is used throughout the application lifecycle.
    /// This class simplifies access to a shared instance of a ScriptableObject
    /// by automatically loading or finding it at runtime when accessed for the first time.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the ScriptableObject that will be treated as a singleton instance.
    /// </typeparam>
    public abstract class SingletonScriptableObject<T> : SerializedScriptableObject where T : SerializedScriptableObject
    {
        /// <summary>
        /// Provides access to the singleton instance of the specified type.
        /// Ensures that only one instance of the object exists and provides a global point of access to it.
        /// </summary>
        private static T _instance;

        #region Properties

        /// <summary>
        /// Gets the singleton instance of the class.
        /// This property provides global access to the single instance of the type,
        /// ensuring that only one instance of the object exists during the application lifecycle.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;

                _instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
                if (_instance == null) Debug.LogError($"No instance of {typeof(T)} found in resources.");
                return _instance;
            }
        }

        #endregion
    }


    /// <summary>
    /// An abstract base class for managing globally accessible serialized configuration assets in Unity.
    /// It ensures that the configuration is loaded and accessible throughout the application,
    /// with support for automatic asset initialization and lifecycle management.
    /// Classes derived from this type represent specific configuration assets.
    /// </summary>
    /// <typeparam name="T">
    /// The derived type of <see cref="SerializedGlobalConfig{T}"/>.
    /// The derived type must inherit from <see cref="SerializedGlobalConfig{T}"/> and provide its own implementation.
    /// </typeparam>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global")]
    public abstract class SerializedGlobalConfig<T> : SerializedScriptableObject, IGlobalConfigEvents
        where T : SerializedGlobalConfig<T>, new()
    {
        // ReSharper disable once StaticMemberInGenericType
        /// <summary>
        /// Represents a configuration attribute that stores metadata or settings
        /// applicable to a specific functionality or component.
        /// </summary>
        private static GlobalConfigAttribute _configAttribute;

        /// <summary>
        /// Represents the static instance of the configuration or object tied to the Singleton pattern, ensuring a single, globally accessible instance throughout the application lifecycle.
        /// </summary>
        private static T _instance;

        #region Properties

        /// <summary>
        /// Indicates whether the instance has been loaded successfully.
        /// </summary>
        public static bool HasInstanceLoaded => GlobalConfigUtility<T>.HasInstanceLoaded;

        /// <summary>
        /// Represents a configuration attribute used to define metadata
        /// or settings associated with a specific configuration entry.
        /// </summary>
        private static GlobalConfigAttribute ConfigAttribute
        {
            get
            {
                if (_configAttribute != null) return _configAttribute;

                _configAttribute = typeof(T).GetCustomAttribute<GlobalConfigAttribute>() ??
                                  new GlobalConfigAttribute(typeof(T).GetNiceName());
                return _configAttribute;
            }
        }

        /// <summary>
        /// Gets the singleton instance of the class.
        /// </summary>
        public static T Instance => GlobalConfigUtility<T>.GetInstance(ConfigAttribute.AssetPath);

        #endregion

        #region Methods

        /// <summary>
        /// Opens the configuration asset in the Unity Editor.
        /// Logs a placeholder message indicating an attempt to launch and open the config window in the editor.
        /// </summary>
        public void OpenInEditor()
        {
            Debug.Log(
                "Downloading, installing and launching the Unity Editor so we can open this config window in the editor, please stand by until pigs can fly and hell has frozen over...");
        }

        /// <summary>
        /// Attempts to load an instance of the asset if it exists.
        /// Ensures that the required asset is initialized and accessible.
        /// </summary>
        public static void LoadInstanceIfAssetExists()
        {
            //GlobalConfigUtility<T>.LoadInstanceIfAssetExists(SerializedGlobalConfig<T>.ConfigAttribute.AssetPath);
            Debug.Log("LoadInstanceIfAssetExists");
        }

        #endregion

        #region Event Functions

        /// <summary>
        /// Triggered the first time the configuration instance is accessed.
        /// Used to perform initialization or setup tasks specific to the configuration lifecycle.
        /// </summary>
        protected virtual void OnConfigInstanceFirstAccessed()
        {
        }

        /// <summary>
        /// Invoked automatically when a configuration file is created.
        /// Handles any required setup or initialization related to the new configuration.
        /// </summary>
        protected virtual void OnConfigAutoCreated()
        {
        }

        #endregion

        #region IGlobalConfigEvents Members

        /// <summary>
        /// Invoked automatically when a configuration file is created.
        /// Handles any required setup or initialization tasks associated with
        /// the creation of a new configuration instance.
        /// </summary>
        void IGlobalConfigEvents.OnConfigAutoCreated()
        {
            OnConfigAutoCreated();
        }

        /// <summary>
        /// Triggered the first time the configuration instance is accessed.
        /// Used to perform initialization or setup tasks specific to the configuration lifecycle.
        /// </summary>
        void IGlobalConfigEvents.OnConfigInstanceFirstAccessed()
        {
            OnConfigInstanceFirstAccessed();
        }

        #endregion
    }
}
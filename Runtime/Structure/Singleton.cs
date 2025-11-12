using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Marmary.Libraries.Structure
{
    /// <summary>
    ///     A static instance of a MonoBehaviour is similar to a singleton, but instead
    ///     of destroying any instance that already exists, it will override it.
    /// </summary>
    /// <typeparam name="T">Type of the MonoBehaviour.</typeparam>
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

    public abstract class SingletonScriptableObject<T> : SerializedScriptableObject where T : SerializedScriptableObject
    {
        private static T instance;

        #region Properties

        public static T Instance
        {
            get
            {
                if (instance != null) return instance;

                instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
                if (instance == null) Debug.LogError($"No instance of {typeof(T)} found in resources.");
                return instance;
            }
        }

        #endregion
    }


    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global")]
    public abstract class SerializedGlobalConfig<T> : SerializedScriptableObject, IGlobalConfigEvents
        where T : SerializedGlobalConfig<T>, new()
    {
        // ReSharper disable once StaticMemberInGenericType
        private static GlobalConfigAttribute configAttribute;
        private static T instance;

        #region Properties

        public static bool HasInstanceLoaded => GlobalConfigUtility<T>.HasInstanceLoaded;

        private static GlobalConfigAttribute ConfigAttribute
        {
            get
            {
                if (configAttribute != null) return configAttribute;

                configAttribute = typeof(T).GetCustomAttribute<GlobalConfigAttribute>() ??
                                  new GlobalConfigAttribute(typeof(T).GetNiceName());
                return configAttribute;
            }
        }

        public static T Instance => GlobalConfigUtility<T>.GetInstance(ConfigAttribute.AssetPath);

        #endregion

        #region Methods

        public void OpenInEditor()
        {
            Debug.Log(
                "Downloading, installing and launching the Unity Editor so we can open this config window in the editor, please stand by until pigs can fly and hell has frozen over...");
        }

        public static void LoadInstanceIfAssetExists()
        {
            //GlobalConfigUtility<T>.LoadInstanceIfAssetExists(SerializedGlobalConfig<T>.ConfigAttribute.AssetPath);
            Debug.Log("LoadInstanceIfAssetExists");
        }

        #endregion

        #region Event Functions

        protected virtual void OnConfigInstanceFirstAccessed()
        {
        }

        protected virtual void OnConfigAutoCreated()
        {
        }

        #endregion

        #region IGlobalConfigEvents Members

        void IGlobalConfigEvents.OnConfigAutoCreated()
        {
            OnConfigAutoCreated();
        }

        void IGlobalConfigEvents.OnConfigInstanceFirstAccessed()
        {
            OnConfigInstanceFirstAccessed();
        }

        #endregion
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic singleton implementation.
/// </summary>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance { get; private set; }

    protected virtual void Awake() {
        if (Instance != null)
            Debug.LogWarning($"Singleton {Instance} already has an instance.");
        else
            Instance = this as T;
    }

    protected virtual void OnApplicationQuit() {
        Instance = null;
    }
}

/// <summary>
/// Basic persistent singleton implementation.
/// </summary>
public abstract class SingletonPersistent<T> : Singleton<T> where T : MonoBehaviour {
    protected override void Awake() {
        if (Instance != null) {
            Destroy(gameObject); //If there is already an instance of the PersistentSingleton, destroys the new one on Awake
        } else {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}

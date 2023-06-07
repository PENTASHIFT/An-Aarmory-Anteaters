using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public List<string> sceneNames;

    public string instanceName;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckForDuplicateInstances();
        CheckIfSceneInList();
    }

    void CheckForDuplicateInstances()
    {
        AudioController[] collection = FindObjectsOfType<AudioController>();

        foreach (AudioController obj in collection)
        {
            if (this != obj)
            {
                if (instanceName == obj.instanceName)
                {
                    DestroyImmediate(obj.gameObject);
                }
            }
        }
    }

    void CheckIfSceneInList()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (sceneNames.Contains(currentScene))
        {
            // Keep the object alive.
        }
        else
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            DestroyImmediate(this.gameObject);
        }
    }
}

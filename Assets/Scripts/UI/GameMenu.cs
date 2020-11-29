using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GameDevTV.Saving;
using RPG.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.UI
{
    public class GameMenu : MonoBehaviour
    {
        const string defaultSaveFile = "save";
        // Start is called before the first frame update
        void Start()
        {
            
        }

        public void NewGame()
        {
            SavingSystem savingSystem = GetComponent<SavingSystem>();
            string path = savingSystem.GetPathFromSaveFile(defaultSaveFile);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            SceneManager.LoadSceneAsync(1);
        }

        public void LoadGame()
        {
            StartCoroutine(GetComponent<SavingSystem>().LoadLastScene(defaultSaveFile));
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using RPG.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RPG.UI
{
    public class PauseMenu : MonoBehaviour
    {
        public Button saveButton;
        public Button loadButton;
        SavingWrapper savingWrapper;
        // Start is called before the first frame update

        void Start()
        {
            saveButton.GetComponent<Button>().onClick.AddListener(SaveGame);
            loadButton.GetComponent<Button>().onClick.AddListener(LoadGame);
            savingWrapper = FindObjectOfType<SavingWrapper>();
        }

        private void LoadGame()
        {
            savingWrapper.Load();
        }

        private void SaveGame()
        {
            savingWrapper.Save();
        }
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gang1057.Ludiwuri.Menu
{

    /// <summary>
    /// Manages the Menu scene
    /// </summary>
    public class MenuManager : MonoBehaviour, ISceneManager
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private GameObject tutorialGameObject;

#pragma warning restore 649

        #endregion

        #region Methods

        public void ShowTutorial()
        {

        }

        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }
        public void Quit()
        {
            Application.Quit();
        }

        #endregion

    }

}
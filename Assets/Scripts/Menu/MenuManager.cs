using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gang1057.Ludiwuri.Menu
{

    /// <summary>
    /// Manages the Menu scene
    /// </summary>
    public class MenuManager : MonoBehaviour, ITransitionAware
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private GameObject tutorialGameObject;

#pragma warning restore 649

        #endregion

        #region Methods

        public void ShowTutorial()
        {
            tutorialGameObject.SetActive(true);
        }

        public void PlayGame()
        {
            Transitioner.Instance.TransitionTo(1);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void OnSceneLoad()
        {

        }

        public void OnTransitionCompleted()
        {
          
        }

        public void OnTransitionStarted()
        {
           
        }

        public void OnSceneUnload()
        {
          
        }

        #endregion

    }

}
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gang1057.Nyctophobia.Menu
{

    /// <summary>
    /// Manages the Menu scene
    /// </summary>
    public class MenuManager : MonoBehaviour, ITransitionAware
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private GameObject tutorialGameObject1;
        [SerializeField] private GameObject tutorialGameObject2;

#pragma warning restore 649

        #endregion

        #region Methods

        public void ShowTutorial1()
        {
            tutorialGameObject1.SetActive(true);
        }

        public void ShowTutorial2()
        {
            tutorialGameObject1.SetActive(false);
            tutorialGameObject2.SetActive(true);
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
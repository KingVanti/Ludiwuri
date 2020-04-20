using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gang1057.Ludiwuri.EndScreen
{

    public class EndScreenManager : MonoBehaviour, ITransitionAware
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private GameObject gameOverTitle;
        [SerializeField] private GameObject winTitle;

#pragma warning restore 649

        #endregion

        #region Methods

        public void Retry()
        {
            Transitioner.Instance.TransitionTo(1);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void OnSceneLoad()
        {
            int gameState = PlayerPrefs.GetInt("GameState");

            if (gameState == 0)
            {
                gameOverTitle.SetActive(true);
            }
            else if (gameState == 1)
            {
                winTitle.SetActive(true);
            }
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
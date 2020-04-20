using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gang1057.Ludiwuri.EndScreen
{

    public class EndScreenManager : MonoBehaviour
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
            SceneManager.LoadScene(1);
        }

        public void Quit()
        {
            Application.Quit();
        }


        private void Awake()
        {
            int gameState = PlayerPrefs.GetInt("GameState");

            if(gameState == 0)
            {
                gameOverTitle.SetActive(true);
            }
            else if (gameState == 1)
            {
                winTitle.SetActive(true);
            }
        }

        #endregion

    }

}
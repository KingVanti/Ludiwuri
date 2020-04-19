using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gang1057.Ludiwuri.Menu
{

    /// <summary>
    /// Manages the Menu scene
    /// </summary>
    public class MenuManager : MonoBehaviour, ISceneManager
    {
        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }
        public void Quit()
        {
            Application.Quit();
            Debug.Log("Game Quitted");
        }
    }

}
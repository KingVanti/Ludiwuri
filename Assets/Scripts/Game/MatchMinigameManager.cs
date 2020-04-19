using UnityEngine;

namespace Gang1057.Ludiwuri.Game
{

    /// <summary>
    /// Manages the Match-mini-game
    /// </summary>
    public class MatchMinigameManager : MonoBehaviour
    {

        #region Fields

        /// <summary>
        /// The game-object
        /// </summary>
        [SerializeField] private GameObject uiGameObject;

        #endregion

        #region Methods

        /// <summary>
        /// Starts the mini-game
        /// </summary>
        public void StartMinigame()
        {
            uiGameObject.SetActive(true);
        }

        /// <summary>
        /// Called when the mini-game is completed
        /// </summary>
        public void OnCompleteMinigame()
        {
            uiGameObject.SetActive(false);
        }

        #endregion

    }

}
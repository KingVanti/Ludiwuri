using UnityEngine;
using UnityEngine.Events;

namespace Gang1057.Ludiwuri.Game
{

    /// <summary>
    /// Manages the Match-mini-game
    /// </summary>
    public class MatchMinigameManager : MonoBehaviour
    {

        #region Fields

        /// <summary>
        /// Called when the mini-game was completed
        /// </summary>
        public UnityEvent onMinigameComplete;

#pragma warning disable 649

        /// <summary>
        /// The game-object
        /// </summary>
        [SerializeField] private GameObject uiGameObject;

#pragma warning restore 649

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

            onMinigameComplete.Invoke();
        }

        #endregion

    }

}
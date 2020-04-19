using UnityEngine;

namespace Gang1057.Ludiwuri.Game.Player
{

    /// <summary>
    /// Master controller for the player
    /// </summary>
    public class MasterPlayerController : MonoBehaviour
    {

        #region Fields

#pragma warning disable 649

        /// <summary>
        /// The lamp the player is holding
        /// </summary>
        [SerializeField] private GameObject candleGameobject;

#pragma warning restore 649

        /// <summary>
        /// Backing field to <see cref="CurrentPlayerController"/>
        /// </summary>
        private PlayerController _curentPlayerController;

        #endregion

        #region Properties

        /// <summary>
        /// The currently active player controller
        /// </summary>
        public PlayerController CurrentPlayerController
        {
            get { return _curentPlayerController; }
            private set { _curentPlayerController = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when the candle is collected
        /// </summary>
        public void OnCollectCandle()
        {
            CurrentPlayerController = GetComponent<WithCandlePlayerController>();

            // TODO: Update animator

            candleGameobject.SetActive(true);
        }


        private void Awake()
        {
            // At the beginning the player starts off without a lamp

            CurrentPlayerController = GetComponent<NoCandlePlayerController>();
        }

        #endregion

    }
}

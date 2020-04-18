using UnityEngine;

namespace Gang1057.Ludiwuri.Game.Player
{

    /// <summary>
    /// Controls the player
    /// </summary>
    public class PlayerController : MonoBehaviour
    {

        #region Fields

        /// <summary>
        /// Backing field to <see cref="MovementController"/>
        /// </summary>
        [SerializeField] private PlayerMovementController _movementController;

        #endregion

        #region Properties

        /// <summary>
        /// The controller used for player movement
        /// </summary>
        public PlayerMovementController MovementController
        {
            get { return _movementController; }
            set { _movementController = value; }
        }

        #endregion

    }

}
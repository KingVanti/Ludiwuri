using Gang1057.Ludiwuri.Game.World;
using UnityEngine;

namespace Gang1057.Ludiwuri.Game.Player
{

    /// <summary>
    /// Base class for all player controllers
    /// </summary>
    public abstract class PlayerController : MonoBehaviour
    {

        #region Fields

        /// <summary>
        /// Backing field to <see cref="MovementController"/>
        /// </summary>
        [SerializeField] private PlayerMovementController _movementController;

        #endregion

        /// <summary>
        /// Backing field to <see cref="CurrentInteractable"/>
        /// </summary>
        private IInteractable _currentInteractable;

        #region Properties

        /// <summary>
        /// The controller used for player movement
        /// </summary>
        public PlayerMovementController MovementController
        {
            get { return _movementController; }
            set { _movementController = value; }
        }

        public IInteractable CurrentInteractable
        {
            get { return _currentInteractable; }
            set
            {
                _currentInteractable = value;

                // TODO: Trigger event (Update UI)
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when a trigger enters the players collider
        /// </summary>
        /// <param name="collider">The collider that entered</param>
        private void OnTriggerEnter2D(Collider2D collider)
        {
            // If the object is an interactable

            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                // Set the current interactable

                CurrentInteractable = interactable;
            }
        }

        /// <summary>
        /// Called when a trigger exits the players collider
        /// </summary>
        /// <param name="collider">The collider that exited</param>
        private void OnTriggerExit2D(Collider2D collider)
        {
            // If the object is an interactable

            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                // Clear the current interactable

                CurrentInteractable = null;
            }
        }

        #endregion

    }

}
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

#pragma warning disable 649

        /// <summary>
        /// Backing field to <see cref="MovementController"/>
        /// </summary>
        [SerializeField] private PlayerMovementController _movementController;

#pragma warning restore 649

        /// <summary>
        /// Backing field to <see cref="CurrentInteractable"/>
        /// </summary>
        private IInteractable _currentInteractable;

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

        /// <summary>
        /// The interactable the player currently stands in front of. Null if there is none
        /// </summary>
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
        /// Called each frame
        /// </summary>
        private void Update()
        {
            // If the player presses "Interact" and is standing in front of something to interact with

            if (Input.GetButton("Interact") && CurrentInteractable != null)

                // Interact with it

                CurrentInteractable.Interact();
        }

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
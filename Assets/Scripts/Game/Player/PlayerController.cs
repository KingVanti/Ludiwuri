using Gang1057.Ludiwuri.Game.World;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Gang1057.Ludiwuri.Game.Player
{

    /// <summary>
    /// Base class for all player controllers
    /// </summary>
    public class PlayerController : MonoBehaviour
    {

        #region Static Properties

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static PlayerController Instance { get; private set; }

        #endregion

        #region Fields

#pragma warning disable 649

        [SerializeField] private int secondsUntilDeath;
        /// <summary>
        /// The players animator
        /// </summary>
        [SerializeField] private Animator anim;
        /// <summary>
        /// Backing field to <see cref="MovementController"/>
        /// </summary>
        [SerializeField] private PlayerMovementController _movementController;
        /// <summary>
        /// Used to play the match mini-game
        /// </summary>
        [SerializeField] private MatchMinigameManager minigameManager;
        [SerializeField] private TextMeshProUGUI matchCountText;
        [SerializeField] private DeathCountdownText deathCountdownText;

#pragma warning restore 649

        /// <summary>
        /// Backing field to <see cref="CurrentInteractable"/>
        /// </summary>
        private IInteractable _currentInteractable;
        /// <summary>
        /// Backing field to <see cref="CandleLit"/>
        /// </summary>
        private bool _candleLit;
        /// <summary>
        /// Backing field to <see cref="MatchCount"/>
        /// </summary>
        private int _matchCount =  5;
        private bool _inLight;

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

        /// <summary>
        /// The number of matches the player currently has
        /// </summary>
        public int MatchCount
        {
            get { return _matchCount; }
            set
            {
                _matchCount = value;
                matchCountText.text = value.ToString();
            }
        }

        public bool CandleLit
        {
            get { return _candleLit; }
            set
            {
                _candleLit = value;

                anim.SetBool("CandleLit", value);
            }
        }

        public bool InLight
        {
            get
            {
                return _inLight;
            }

            private set
            {
                if (value != _inLight)
                {
                    _inLight = value;

                    if (!value)
                    {
                        StartCoroutine(CountDownToDeath());
                    }
                    else
                    {
                        StopAllCoroutines();
                        deathCountdownText.SetCountdownTime(null);
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Teleports the player to a position
        /// </summary>
        /// <param name="position">The position to teleport to</param>
        public void TeleportTo(Vector2 position)
        {
            transform.position = position;
        }

        /// <summary>
        /// Called when the match mini-game is completed
        /// </summary>
        public void OnMatchMinigameComplete()
        {
            // Remove a match

            MatchCount--;
            CandleLit = true;
        }


        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// Called each frame
        /// </summary>
        private void Update()
        {
            // If the player presses "Interact" and is standing in front of something to interact with that is interactable

            if (Input.GetButtonDown("Interact") && CurrentInteractable != null && CurrentInteractable.Interactable)

                // Interact with it

                CurrentInteractable.Interact();

            // If the player pressed the reload button, his light is not burning and he has matches

            if (Input.GetButtonDown("Reload") && !CandleLit && MatchCount > 0)

                minigameManager.StartMinigame();

            // Update InLight property

            InLight = RoomManager.Instance.PlayerInLight(transform.position);
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
            // If the object is the current interactable

            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (interactable == CurrentInteractable)
            {
                // Clear the current interactable

                CurrentInteractable = null;
            }
        }

        private IEnumerator CountDownToDeath()
        {
            int countDownTime = secondsUntilDeath;

            while (countDownTime > 0)
            {
                deathCountdownText.SetCountdownTime(countDownTime);
                yield return new WaitForSeconds(1);
                countDownTime--;
            }

            // TODO: Trigger death
        }

        #endregion

    }

}
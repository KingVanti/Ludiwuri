using Gang1057.Ludiwuri.Game.World;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Gang1057.Ludiwuri.Game.Player
{

    /// <summary>
    /// Base class for all player controllers
    /// </summary>
    public class PlayerController : MonoBehaviour, ITransitionAware
    {

        #region Static Properties

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static PlayerController Instance { get; private set; }

        #endregion

        #region Fields

        public FloatEvent onSanityChange;
        public Candle candle;

#pragma warning disable 649

        [SerializeField] private float sanityDamageSpeed;
        [SerializeField] private float sanityHealSpeed;
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
        [SerializeField] private TextMeshProUGUI interactionPrompt;

#pragma warning restore 649

        /// <summary>
        /// Backing field to <see cref="MatchCount"/>
        /// </summary>
        private int _matchCount;
        private bool _inLight = true;
        private bool active;
        private IInteractable _currentInteractable;
        private float _sanity;
        private LightState _currentLightState;

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

                UpdateInteractionPrompt();
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

                UpdateInteractionPrompt();
            }
        }

        public float Sanity
        {
            get { return _sanity; }
            private set
            {
                _sanity = Mathf.Clamp(value, 0, 100);

                onSanityChange.Invoke(_sanity);

                if (_sanity == 0)
                {
                    GlobalSoundPlayer.Instance.PlaySound("Scream");
                    Invoke("GoToEndScreen", 2);

                    enabled = false;
                    MovementController.Locked = true;
                }
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

                    UpdateCurrentLightState();
                }
            }
        }

        public LightState CurrentLightState
        {
            get { return _currentLightState; }
            private set
            {
                if ((_currentLightState == LightState.InLight || _currentLightState == LightState.InOwnLight) && value == LightState.InShadow)
                    GlobalSoundPlayer.Instance.PlaySound("Whimper");

                _currentLightState = value;
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
            MovementController.Locked = false;

            MatchCount--;

            candle.Light();
        }

        public void UpdateInteractionPrompt()
        {
            interactionPrompt.text = _currentInteractable != null && _currentInteractable.Interactable ? _currentInteractable.Prompt : "";
        }

        public void UpdateCurrentLightState()
        {
            if (InLight)
                CurrentLightState = LightState.InLight;
            else if (candle.Lit)
                CurrentLightState = LightState.InOwnLight;
            else
                CurrentLightState = LightState.InShadow;
        }

        public void OnSceneLoad()
        {
            Instance = this;

            MatchCount = 5;
            Sanity = 100;
            CurrentInteractable = null;
        }

        public void OnTransitionCompleted()
        {
            active = true;
        }

        public void OnTransitionStarted()
        {

        }

        public void OnSceneUnload()
        {

        }



        private void GoToEndScreen()
        {
            PlayerPrefs.SetInt("GameState", 0);
            Transitioner.Instance.TransitionTo(2);
        }

        /// <summary>
        /// Called each frame
        /// </summary>
        private void Update()
        {
            if (active)
            {
                // If the player presses "Interact" and is standing in front of something to interact with that is interactable

                if (Input.GetButtonDown("Interact") && CurrentInteractable != null && CurrentInteractable.Interactable)

                    // Interact with it

                    CurrentInteractable.Interact();

                // If the player pressed the reload button, his light is not burning and he has matches

                if (Input.GetButtonDown("Reload") && !candle.Lit && MatchCount > 0)
                {
                    MovementController.Locked = true;
                    minigameManager.StartMinigame();
                }

                // Update InLight property

                InLight = RoomManager.Instance.PlayerInLight(transform.position);

                switch (CurrentLightState)
                {
                    case LightState.InLight:
                        Sanity += sanityHealSpeed * Time.deltaTime;
                        break;
                    case LightState.InOwnLight:
                        Sanity -= sanityDamageSpeed / 2 * Time.deltaTime;
                        break;
                    case LightState.InShadow:
                        Sanity -= sanityDamageSpeed * Time.deltaTime;
                        break;
                }
            }
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

        #endregion

        #region Enums

        /// <summary>
        /// Possible light states
        /// </summary>
        public enum LightState
        {
            InLight,
            InOwnLight,
            InShadow
        }

        #endregion

        #region SubClasses

        [System.Serializable]
        public class FloatEvent : UnityEvent<float> { }

        #endregion

    }

}
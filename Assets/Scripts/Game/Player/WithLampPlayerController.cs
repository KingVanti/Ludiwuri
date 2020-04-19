using UnityEngine;

namespace Gang1057.Ludiwuri.Game.Player
{

    /// <summary>
    /// Controls the player while he has a lamp
    /// </summary>
    public class WithLampPlayerController : PlayerController
    {

        #region Fields

#pragma warning disable 649

        /// <summary>
        /// The max number of health points the lamp can have
        /// </summary>
        [SerializeField] private int maxLampHealth;

#pragma warning restore 649

        /// <summary>
        /// Backing field to <see cref="Guarding"/>
        /// </summary>
        private bool _guarding;
        /// <summary>
        /// Backing field to <see cref="LampHealth"/>
        /// </summary>
        private int _lampHealth;

        #endregion

        #region Properties

        /// <summary>
        /// Whether the player is currently guarding the candle
        /// </summary>
        public bool Guarding
        {
            get { return _guarding; }
            set
            {
                _guarding = value;

                // TODO: Update animator
                // TODO: Set candle invincible

                MovementController.Locked = value;
            }
        }

        /// <summary>
        /// The lamps current health
        /// </summary>
        public int LampHealth
        {
            get { return _lampHealth; }
            private set
            {
                _lampHealth = Mathf.Clamp(0, maxLampHealth, value);

                // TODO: Update UI
            }
        }

        #endregion

        #region Methods

        private void Update()
        {
            // Update "Guarding" property

            bool guarding = Input.GetButton("Guard");

            if (guarding != Guarding)
                Guarding = guarding;
        }

        #endregion

    }

}
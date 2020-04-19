using UnityEngine;

namespace Gang1057.Ludiwuri.Game.Player
{

    /// <summary>
    /// Controls the player while he has a lamp
    /// </summary>
    public class WithLampPlayerController : PlayerController
    {

        #region Fields

        /// <summary>
        /// Backing field to <see cref="Guarding"/>
        /// </summary>
        private bool _guarding;

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
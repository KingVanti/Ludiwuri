﻿using UnityEngine;

namespace Gang1057.Ludiwuri.Game.Player
{

    /// <summary>
    /// Controls the player while he has a candle
    /// </summary>
    public class WithCandlePlayerController : PlayerController
    {

        #region Fields

#pragma warning disable 649

        /// <summary>
        /// The max number of health points the lamp can have
        /// </summary>
        [SerializeField] private int maxLampHealth;
        /// <summary>
        /// The number of health points a match refills
        /// </summary>
        [SerializeField] private int matchRefillValue;
        /// <summary>
        /// Used to play the match mini-game
        /// </summary>
        [SerializeField] private MatchMinigameManager minigameManager;

#pragma warning restore 649

        /// <summary>
        /// Backing field to <see cref="Guarding"/>
        /// </summary>
        private bool _guarding;
        /// <summary>
        /// Backing field to <see cref="CandleHealth"/>
        /// </summary>
        private int _candleHealth;
        /// <summary>
        /// Backing field to <see cref="MatchCount"/>
        /// </summary>
        private int _matchCount;

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
        /// The candles current health
        /// </summary>
        public int CandleHealth
        {
            get { return _candleHealth; }
            private set
            {
                _candleHealth = Mathf.Clamp(0, maxLampHealth, value);

                // TODO: Update UI
            }
        }

        /// <summary>
        /// The number of matches the player currently has
        /// </summary>
        public int MatchCount
        {
            get { return _matchCount; }
            set { _matchCount = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Try to deal candle damage. Wont work if the player is guarding
        /// </summary>
        /// <param name="damage">The number of damage points</param>
        public void TryCandleLampDamage(int damage)
        {
            // If the player is not guarding

            if (!Guarding)

                // Deal damage

                DealCandleDamage(damage);
        }

        /// <summary>
        /// Called when the match mini-game is completed
        /// </summary>
        public void OnMatchMinigameComplete()
        {
            // Remove a match

            MatchCount--;

            // Refill the candles health

            CandleHealth += matchRefillValue;
        }


        /// <summary>
        /// Deals damage to the candle
        /// </summary>
        /// <param name="damage">The number of damage points</param>
        private void DealCandleDamage(int damage)
        {
            CandleHealth -= damage;

            // TODO: Kill player if no health is left
        }

        private void Update()
        {
            // Update "Guarding" property

            bool guarding = Input.GetButton("Guard");

            if (guarding != Guarding)
                Guarding = guarding;

            // If the Reload button is pressed and the player still has matches

            if (Input.GetButtonDown("Reload") && MatchCount > 0)
            {
                // Stop the player and start the mini-game

                MovementController.Locked = true;
                minigameManager.StartMinigame();
            }
        }

        #endregion

    }

}
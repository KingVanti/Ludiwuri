using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Gang1057.Ludiwuri.Game.World.Collectibles
{

    /// <summary>
    /// Gives the player a candle when collected
    /// </summary>
    public class Candle : Collectible
    {

        #region Fields

#pragma warning disable 649

        /// <summary>
        /// The candles light source
        /// </summary>
        [SerializeField] private Light2D source;

#pragma warning restore 649

        #endregion

        #region Properties

        /// <summary>
        /// Sets whether the candle is lit
        /// </summary>
        public bool Lit
        {
            set
            {
                source.enabled = value;

                // TODO: Update animator
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        protected override void OnCollected()
        {
            // TODO: Give player candle
        }

        #endregion

    }

}
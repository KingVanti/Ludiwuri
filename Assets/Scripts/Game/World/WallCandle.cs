using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// A candle that is mounted to the wall
    /// </summary>
    public class WallCandle : MonoBehaviour, IInteractable
    {

        #region Fields

        /// <summary>
        /// The candles light source
        /// </summary>
        [SerializeField] private Light2D lightSource;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether the candle is currently lit
        /// </summary>
        public bool Lit { get; private set; } = true;

        /// <inheritdoc/>
        public bool Interactable { get { return !Lit; } }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public void Interact()
        {
            Lit = true;
        }

        #endregion

    }

}
using Gang1057.Ludiwuri.Game.Player;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// A candle that is mounted to the wall
    /// </summary>
    public class WallCandle : LightSource, IInteractable
    {

        #region Properties

        /// <inheritdoc/>
        public bool Interactable { get { return !Lit && PlayerController.Instance.candle.Lit; } }

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
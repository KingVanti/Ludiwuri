using Gang1057.Nyctophobia.Game.Player;

namespace Gang1057.Nyctophobia.Game.World
{

    /// <summary>
    /// A candle that is mounted to the wall
    /// </summary>
    public class WallCandle : LightSource, IInteractable
    {

        #region Properties

        /// <inheritdoc/>
        public bool Interactable { get { return !Lit && PlayerController.Instance.candle.Lit; } }

        public string Prompt { get { return "Light candle"; } }

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
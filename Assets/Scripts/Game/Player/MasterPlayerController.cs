namespace Gang1057.Ludiwuri.Game.Player
{

    /// <summary>
    /// Master controller for the player
    /// </summary>
    public class MasterPlayerController
    {

        #region Fields

        /// <summary>
        /// Backing field to <see cref="CurrentPlayerController"/>
        /// </summary>
        private PlayerController _curentPlayerController;

        #endregion

        #region Properties

        /// <summary>
        /// The currently active player controller
        /// </summary>
        public PlayerController CurrentPlayerController
        {
            get { return _curentPlayerController; }
            set { _curentPlayerController = value; }
        }

        #endregion

    }
}

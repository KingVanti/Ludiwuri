namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// Implemented by all interactable objects
    /// </summary>
    public interface IInteractable
    {

        #region Properties

        /// <summary>
        /// Indicates whether this intractable is currently interactable
        /// </summary>
        public bool Interactable { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Interacts with the object
        /// </summary>
        void Interact();

        #endregion

    }

}
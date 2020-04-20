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
        bool Interactable { get; }

        /// <summary>
        /// Prompt that is displayed before interacting with the object
        /// </summary>
        string Prompt { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Interacts with the object
        /// </summary>
        void Interact();

        #endregion

    }

}
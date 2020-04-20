using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World.Collectibles
{

    /// <summary>
    /// Base class for all collectibles
    /// </summary>
    public abstract class Collectible : MonoBehaviour, IInteractable
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private string _prompt;

#pragma warning restore 649

        #endregion

        #region Properties

        /// <inheritdoc/>
        public bool Interactable { get { return true; } }

        public string Prompt { get { return _prompt; } }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public void Interact()
        {
            // Collect this collectible

            Collect();
        }

        /// <summary>
        /// Called when the pickup is collected
        /// </summary>
        protected abstract void OnCollected();


        /// <summary>
        /// Collects this collectible
        /// </summary>
        private void Collect()
        {
            // Handle collection logic

            OnCollected();
        }

        #endregion

    }

}
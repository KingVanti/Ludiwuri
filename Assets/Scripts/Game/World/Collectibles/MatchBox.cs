using Gang1057.Ludiwuri.Game.Player;
using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World.Collectibles
{

    /// <summary>
    /// Collectible matches
    /// </summary>
    public class MatchBox : Collectible
    {

        #region Fields

#pragma warning disable 649

        /// <summary>
        /// The number of matches in this pack
        /// </summary>
        [SerializeField] private int matchCount;

#pragma warning restore 649

        #endregion

        #region Properties

        public MatchSpawnPoint Location { get; set; }

        #endregion

        #region Methods

        /// <inheritdoc/>
        protected override void OnCollected()
        {
            PlayerController.Instance.MatchCount += matchCount;
            Location.MatchBox = null;
            Location = null;
            RoomManager.Instance.Relocate(this);
        }

        #endregion

    }

}
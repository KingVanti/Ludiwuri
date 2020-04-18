using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World.Collectibles
{

    /// <summary>
    /// Collectible matches
    /// </summary>
    public class MatchPack : Collectible
    {

        #region Fields

        /// <summary>
        /// The number of matches in this pack
        /// </summary>
        [SerializeField] private int matchCount;

        #endregion

        #region Methods

        /// <inheritdoc/>
        protected override void OnCollected()
        {
            // TODO: Update players match count
        }

        #endregion

    }

}
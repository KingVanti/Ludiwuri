using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World.Collectibles
{

    /// <summary>
    /// Collectible matches
    /// </summary>
    public class MatchPack : Collectible
    {

        #region Fields

#pragma warning disable 649

        /// <summary>
        /// The number of matches in this pack
        /// </summary>
        [SerializeField] private int matchCount;

#pragma warning restore 649

        #endregion

        #region Methods

        /// <inheritdoc/>
        protected override void OnCollected()
        {
            Debug.Log($"Collected {matchCount} matches!");

            // TODO: Update players match count
        }

        #endregion

    }

}
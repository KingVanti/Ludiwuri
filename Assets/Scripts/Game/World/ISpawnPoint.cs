using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// Implemented by all scripts the player can spawn on
    /// </summary>
    public interface ISpawnPoint
    {

        #region Properties

        /// <summary>
        /// The position at which to spawn the player
        /// </summary>
        Vector2 Position { get; }

        #endregion

    }

}
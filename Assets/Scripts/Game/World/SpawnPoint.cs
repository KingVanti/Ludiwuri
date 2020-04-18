using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// Base class for all scripts the player can spawn on
    /// </summary>
    public abstract class SpawnPoint : MonoBehaviour
    {

        #region Properties

        /// <summary>
        /// The position at which to spawn the player
        /// </summary>
        Vector2 Position { get; }

        #endregion

    }

}
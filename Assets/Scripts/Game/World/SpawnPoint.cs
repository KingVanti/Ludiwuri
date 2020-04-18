using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// Object that the player can spawn on
    /// </summary>
    public class SpawnPoint : MonoBehaviour
    {

        #region Properties

        /// <summary>
        /// The position at which to spawn the player
        /// </summary>
        public virtual Vector2 Position { get { return transform.position; } }

        #endregion

    }

}
using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// Object that the player can spawn on
    /// </summary>
    public class SpawnPoint : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Vector2 spawnOffet;

        #endregion

        #region Properties

        /// <summary>
        /// The position at which to spawn the player
        /// </summary>
        public virtual Vector2 Position { get { return spawnOffet + (Vector2)transform.position; } }

        #endregion

    }

}
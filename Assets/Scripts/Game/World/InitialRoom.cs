using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// The room the game starts in
    /// </summary>
    public class InitialRoom : Room
    {

        #region Properties

        /// <summary>
        /// The bed the player starts in
        /// </summary>
        public ISpawnPoint Bed { get; private set; }

        #endregion

        #region Constructors

        public InitialRoom(string name, GameObject roomGameObject) : base(name, roomGameObject)
        {
            Bed = roomGameObject.GetComponentInChildren<ISpawnPoint>();
        }

        #endregion

    }

}
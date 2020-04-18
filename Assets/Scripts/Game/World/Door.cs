using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// Used to move between rooms
    /// </summary>
    public class Door : SpawnPoint
    {

        #region Fields

#pragma warning disable 649

        /// <summary>
        /// Backing field to <see cref="Locked"/>
        /// </summary>
        [SerializeField] private bool _locked;
        /// <summary>
        /// Backing field to <see cref="ConnectedRoomName"/>
        /// </summary>
        [SerializeField] private string _connectedRoomName;

#pragma warning restore 649

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether the door is unlocked
        /// </summary>
        public bool Locked
        {
            get { return _locked; }
            private set { _locked = value; }
        }

        /// <summary>
        /// The name of the room this door connects to
        /// </summary>
        public string ConnectedRoomName
        {
            get { return _connectedRoomName; }
            set { _connectedRoomName = value; }
        }

        /// <inheritdoc/>
        public Vector2 Position { get { return transform.position; } }

        #endregion

    }

}
using UnityEngine;

namespace Gang1057.Nyctophobia.Game.World
{

    /// <summary>
    /// Used to move between rooms
    /// </summary>
    public class Door : SpawnPoint, IInteractable
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private string _prompt;
        /// <summary>
        /// Backing field to <see cref="ConnectedRoomName"/>
        /// </summary>
        [SerializeField] private string _connectedRoomName;

#pragma warning restore 649

        #endregion

        #region Properties

        /// <summary>
        /// The name of the room this door connects to
        /// </summary>
        public string ConnectedRoomName
        {
            get { return _connectedRoomName; }
            set { _connectedRoomName = value; }
        }

        /// <inheritdoc/>
        public bool Interactable { get { return true; } }

        public string Prompt { get { return _prompt; } }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public void Interact()
        {
            // Go to the connected room

            RoomManager.Instance.EnterRoom(ConnectedRoomName);
        }

        #endregion

    }

}
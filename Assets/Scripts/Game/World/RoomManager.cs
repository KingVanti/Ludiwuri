using System.Collections.Generic;
using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// Manages the loading of rooms
    /// </summary>
    public class RoomManager : MonoBehaviour
    {

        #region Fields

        /// <summary>
        /// A dictionary of cached rooms, indexed by their name
        /// </summary>
        private Dictionary<string, GameObject> cachedRooms = new Dictionary<string, GameObject>();
        /// <summary>
        /// The currently active room
        /// </summary>
        private GameObject currentRoom;

        #endregion

        #region Methods

        /// <summary>
        /// Loads a room with the given name
        /// </summary>
        /// <param name="roomName">The rooms name</param>
        public void LoadRoom(string roomName)
        {
            // Declare variable for the room

            GameObject room = null;

            // If the room is already cached

            if (cachedRooms.ContainsKey(roomName))

                // Get the room from the cache

                room = cachedRooms[roomName];

            // If it is not yet cached

            else
            {
                // Get the room asset with requested name

                RoomAsset roomAsset = Resources.Load<RoomAsset>($"Rooms/{roomName}");

                // Load the room

                room = LoadRoomFromAsset(roomAsset);
            }

            // Enter the loaded room

            EnterRoom(room);
        }


        /// <summary>
        /// Loads a room 
        /// </summary>
        /// <param name="roomAsset">The rooms asset</param>
        /// <returns>The loaded room</returns>
        private GameObject LoadRoomFromAsset(RoomAsset roomAsset)
        {
            // Instantiate the prefab

            GameObject room = Instantiate(roomAsset.RoomPrefab, transform);

            // Cache the room

            cachedRooms.Add(roomAsset.RoomName, room);

            // Return the loaded room

            return room;
        }

        /// <summary>
        /// Enters the given room
        /// </summary>
        /// <param name="room">The room</param>
        private void EnterRoom(GameObject room)
        {
            // If there is currently a room

            if (currentRoom != null)

                // Deactivate it

                currentRoom.SetActive(false);

            // Activate the new room

            room.SetActive(true);

            // TODO: Teleport player to door
        }

        private void Awake()
        {
            LoadRoom("TestRoom");
        }

        #endregion

    }

}
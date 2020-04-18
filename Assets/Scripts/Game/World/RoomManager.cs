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
        private Dictionary<string, Room> cachedRooms = new Dictionary<string, Room>();
        /// <summary>
        /// The currently active room
        /// </summary>
        private Room currentRoom;

        #endregion

        #region Methods

        /// <summary>
        /// Loads a room with the given name
        /// </summary>
        /// <param name="roomName">The rooms name</param>
        public void LoadRoom(string roomName)
        {
            // Declare variable for the room

            Room room = null;

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
        private Room LoadRoomFromAsset(RoomAsset roomAsset)
        {
            // Instantiate the prefab

            GameObject roomGameObject = Instantiate(roomAsset.RoomPrefab, transform);

            // Create a room

            Room room = new Room(roomAsset.name, roomGameObject);

            // Cache the room

            cachedRooms.Add(room.Name, room);

            // Return the loaded room

            return room;
        }

        /// <summary>
        /// Enters the given room
        /// </summary>
        /// <param name="room">The room</param>
        private void EnterRoom(Room room)
        {
            // If there is currently a room

            if (currentRoom != null)

                // Exit it

                currentRoom.OnExit();

            // Enter the new room

            room.OnEnter();

            // TODO: Teleport player to door

            // Set the room to be the current one

            currentRoom = room;
        }

        private void Awake()
        {
            LoadRoom("TestRoom");
        }

        #endregion

    }

}
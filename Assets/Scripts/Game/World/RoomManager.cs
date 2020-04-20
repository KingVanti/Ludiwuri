using Gang1057.Ludiwuri.Game.Player;
using Gang1057.Ludiwuri.Game.World.Collectibles;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// Manages the loading of rooms
    /// </summary>
    public class RoomManager : MonoBehaviour
    {

        #region Fields

        /// <summary>
        /// Called when a room is entered
        /// </summary>
        public RoomEvent onRoomEntered;

#pragma warning disable 649

        /// <summary>
        /// The initial rooms name
        /// </summary>
        [SerializeField] private string initialRoomName;

        /// <summary>
        /// The player
        /// </summary>
        [SerializeField] private PlayerController player;

#pragma warning restore 649

        /// <summary>
        /// A dictionary of cached rooms, indexed by their name
        /// </summary>
        private Dictionary<string, Room> rooms = new Dictionary<string, Room>();
        /// <summary>
        /// The currently active room
        /// </summary>
        private Room currentRoom;

        #endregion

        #region Properties

        /// <summary>
        /// The singleton instance of this class
        /// </summary>
        public static RoomManager Instance { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Enters the room with the given name
        /// </summary>
        /// <param name="roomName">The rooms name</param>
        public void EnterRoom(string roomName)
        {
            // Get the room with that name

            Room room = rooms[roomName];

            // Enter the room

            EnterRoom(room);
        }

        public void Relocate(MatchBox matchBox)
        {
            IEnumerable<Room> possibleRooms = rooms.Values.Where(r => r != currentRoom && r.FreeMatchSpawnPoint);

            Room nextLocation = possibleRooms.ElementAt(UnityEngine.Random.Range(0, possibleRooms.Count()));

            nextLocation.Place(matchBox);
        }

        public bool PlayerInLight(Vector2 position)
        {
            return currentRoom.PlayerInLight(position);
        }


        /// <summary>
        /// Enters the given room
        /// </summary>
        /// <param name="room">The room</param>
        private void EnterRoom(Room room)
        {
            // Get the current rooms name

            string lastRoomName = currentRoom.Name;

            // Exit the current room

            currentRoom.Hide();

            // Enter the new room

            room.Show();

            // Get the door that connects to the previous room

            Door enterDoor = room.GetDoorToRoom(lastRoomName);

            // Teleport the player to it

            player.TeleportTo(enterDoor.Position);

            // Set the room to be the current one

            currentRoom = room;

            // Fire enter event

            onRoomEntered.Invoke(room);
        }

        /// <summary>
        /// Loads the room the game starts in
        /// </summary>
        private void EnterInitialRoom()
        {
            // Get the room with the initial rooms name

            Room room = rooms[initialRoomName];

            // Enter the new room

            room.Show();

            // Get the bed spawn-point

            SpawnPoint bed = room.GetSpawnPoint("Bed");

            // Teleport the player to the bed

            player.TeleportTo(bed.Position);

            // Set the room as the current room

            currentRoom = room;

            // Fire enter event

            onRoomEntered.Invoke(room);
        }

        private void LoadRooms()
        {
            foreach (GameObject roomPrefab in Resources.LoadAll<GameObject>("Rooms"))
            {
                // Instantiate the prefab

                GameObject roomGameObject = Instantiate(roomPrefab, transform);

                // Create a room

                Room room = new Room(roomPrefab.name, roomGameObject);

                room.Hide();

                // Store the room

                rooms.Add(room.Name, room);
            }
        }

        private void Awake()
        {
            LoadRooms();

            Instance = this;

            // Enter the initial room

            EnterInitialRoom();
        }

        #endregion

        #region SubClasses

        /// <summary>
        /// Event with <see cref="Room"/> parameter
        /// </summary>
        [System.Serializable]
        public class RoomEvent : UnityEvent<Room> { }

        #endregion

    }

}
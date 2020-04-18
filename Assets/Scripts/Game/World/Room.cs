using System.Linq;
using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// Represents a room
    /// </summary>
    public class Room
    {

        #region Fields

        /// <summary>
        /// The rooms game-object
        /// </summary>
        private GameObject roomGameObject;
        /// <summary>
        /// The doors that lead in and out of this room
        /// </summary>
        private Door[] doors;

        #endregion

        #region Properties

        /// <summary>
        /// The rooms name
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructors

        public Room(string name, GameObject roomGameObject)
        {
            Name = name;
            this.roomGameObject = roomGameObject;

            doors = roomGameObject.GetComponentsInChildren<Door>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepares the room for entering
        /// </summary>
        public void OnEnter()
        {
            roomGameObject.SetActive(true);
        }

        /// <summary>
        /// Prepares the room for exiting
        /// </summary>
        public void OnExit()
        {
            roomGameObject.SetActive(false);
        }

        /// <summary>
        /// Get a door in this room that connects to a specific other room
        /// </summary>
        /// <param name="roomName">The name of the room</param>
        /// <returns>The door that leads to that room</returns>
        public Door GetDoorToRoom(string roomName)
        {
            return doors.Where(d => d.ConnectedRoomName == roomName).FirstOrDefault();
        }

        #endregion

    }

}
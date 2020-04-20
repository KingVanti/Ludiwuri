using System.Collections.Generic;
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
        /// <summary>
        /// The spawn-points the player can spawn at in this room
        /// </summary>
        private Dictionary<string, SpawnPoint> spawnPoints = new Dictionary<string, SpawnPoint>();
        private LightSource[] lightSources;

        #endregion

        #region Properties

        /// <summary>
        /// The rooms name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The width of the room
        /// </summary>
        public float RoomWidth { get; private set; }

        #endregion

        #region Constructors

        public Room(string name, GameObject roomGameObject)
        {
            Name = name;
            this.roomGameObject = roomGameObject;

            doors = roomGameObject.GetComponentsInChildren<Door>();

            foreach (SpawnPoint spawnPoint in roomGameObject.GetComponentsInChildren<SpawnPoint>())
                spawnPoints.Add(spawnPoint.gameObject.name, spawnPoint);

            foreach (Transform transform in roomGameObject.transform)

                if (transform.tag == "BackWall")
                {
                    RoomWidth = transform.GetComponent<SpriteRenderer>().size.x;
                    break;
                }

            lightSources = roomGameObject.GetComponentsInChildren<LightSource>();
        }

        #endregion

        #region Methods

        public void Show()
        {
            roomGameObject.SetActive(true);
        }

        public void Hide()
        {
            roomGameObject.SetActive(false);
        }

        public bool PlayerInLight(Vector2 position)
        {
            return lightSources.Any(l => l.Lit && Vector2.Distance(position, l.transform.position) < l.Radius);
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

        /// <summary>
        /// Gets a spawn-point with a specific name in this room
        /// </summary>
        /// <param name="name">The spawn-points name</param>
        /// <returns>The spawn-point</returns>
        public SpawnPoint GetSpawnPoint(string name)
        {
            return spawnPoints[name];
        }

        #endregion

    }

}
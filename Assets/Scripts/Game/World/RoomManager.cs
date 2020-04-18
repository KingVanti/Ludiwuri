using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// Manages the loading of rooms
    /// </summary>
    public class RoomManager : MonoBehaviour
    {

        #region Methods

        /// <summary>
        /// Loads a room with the given name
        /// </summary>
        /// <param name="roomName">The rooms name</param>
        public void LoadRoom(string roomName)
        {
            // Get the room asset with requested name

            RoomAsset roomAsset = Resources.Load<RoomAsset>($"Rooms/{roomName}");

            // Load the associated room prefab

            LoadRoom(roomAsset.RoomPrefab);
        }


        /// <summary>
        /// Loads a room 
        /// </summary>
        /// <param name="roomPrefab">The rooms prefab</param>
        private void LoadRoom(GameObject roomPrefab)
        {
            // TODO: Implement room loading
        }

        #endregion

    }

}
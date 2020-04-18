using UnityEngine;

namespace Gang1057.Ludiwuri.Game.World
{

    /// <summary>
    /// Stores information about a room
    /// </summary>
    [CreateAssetMenu(menuName = "Ludiwuri/Room", fileName = "Unnamed Room")]
    public class RoomAsset : ScriptableObject
    {

        #region Fields

        /// <summary>
        /// Backing field to <see cref="RoomPrefab"/>
        /// </summary>
        [SerializeField] private GameObject _roomPrefab;

        #endregion

        #region Properties

        /// <summary>
        /// The rooms name
        /// </summary>
        public string RoomName { get { return name; } }

        /// <summary>
        /// The prefab that stores the room
        /// </summary>
        public GameObject RoomPrefab { get { return _roomPrefab; } }

        #endregion

    }

}

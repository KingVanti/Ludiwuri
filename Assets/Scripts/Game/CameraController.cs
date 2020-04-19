using Gang1057.Ludiwuri.Game.World;
using UnityEngine;

namespace Gang1057.Ludiwuri.Game
{

    /// <summary>
    /// Controls the camera in the game scene
    /// </summary>
    public class CameraController : MonoBehaviour
    {

        #region Fields

#pragma warning disable 649

        /// <summary>
        /// The factor with which the camera smooths its motion
        /// </summary>
        [SerializeField] private float smoothing;
        /// <summary>
        /// The offset from the player
        /// </summary>
        [SerializeField] private Vector3 cameraOffset;
        /// <summary>
        /// The transform the camera follows
        /// </summary>
        [SerializeField] private Transform playerTransform;

#pragma warning restore 649

        #endregion

        #region Methods

        /// <summary>
        /// Called when the room changes
        /// </summary>
        /// <param name="room">The room that was entered</param>
        public void OnChangeRoom(Room room)
        {
            // Teleport camera to player

            transform.position = playerTransform.position + cameraOffset;
        }


        private void FixedUpdate()
        {
            // Smoothly follow the player

            transform.position = Vector3.Lerp(
                transform.position,
                playerTransform.position + cameraOffset,
                smoothing
                );
        }

        #endregion

    }

}
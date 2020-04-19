using System.Collections;
using System.Collections.Generic;
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
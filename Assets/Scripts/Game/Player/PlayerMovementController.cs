using UnityEngine;

namespace Gang1057.Ludiwuri.Game.Player
{

    /// <summary>
    /// Controls the players movement
    /// </summary>
    public class PlayerMovementController : MonoBehaviour
    {

        #region Fields

#pragma warning disable 649

        /// <summary>
        /// The speed with which the player walks
        /// </summary>
        [SerializeField] private float walkSpeed;
        /// <summary>
        /// The speed with which the player runs
        /// </summary>
        [SerializeField] private float runSpeed;
        /// <summary>
        /// The rigid-body used for moving the player
        /// </summary>
        [SerializeField] private Rigidbody2D rb;

#pragma warning restore 649

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether the player is currently running
        /// </summary>
        private bool Running { get { return Input.GetButton("Sprint"); } }

        /// <summary>
        /// The speed with which the player is currently moving
        /// </summary>
        private float Speed { get { return Running ? runSpeed : walkSpeed; } }

        #endregion

        #region Methods

        /// <summary>
        /// Called every frame
        /// </summary>
        private void Update()
        {
            // Move the player horizontally

            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, 0);
        }

        #endregion

    }

}
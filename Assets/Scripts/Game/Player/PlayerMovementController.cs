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

        /// <summary>
        /// Backing field to <see cref="Running"/>
        /// </summary>
        private bool _running = false;
        /// <summary>
        /// Backing field to <see cref="Speed"/>
        /// </summary>
        private float _speed = 0;
        /// <summary>
        /// Backing field to <see cref="FaceingDirection"/>
        /// </summary>
        private Directions _faceingDirection = Directions.Right;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether the player is currently running
        /// </summary>
        private bool Running
        {
            get { return _running; }
            set
            {
                _running = value;

                Speed = value ? runSpeed : walkSpeed;

                // TODO: Update animator
            }
        }

        /// <summary>
        /// The speed with which the player is currently moving
        /// </summary>
        private float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        /// <summary>
        /// The direction in whcih the player is currently facing
        /// </summary>
        private Directions FaceingDirection
        {
            get { return _faceingDirection; }
            set
            {
                _faceingDirection = value;

                // TODO: Update sprite renderer
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called every frame
        /// </summary>
        private void Update()
        {
            // Update "Running" property

            bool running = Input.GetButton("Sprint");

            if (running != Running)
                Running = running;

            // Move the player horizontally

            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, 0);
        }

        #endregion

        #region Enums

        /// <summary>
        /// The directions the player can face
        /// </summary>
        public enum Directions
        {
            /// <summary>
            /// The player is facing to the left
            /// </summary>
            Left,

            /// <summary>
            /// The player is facing to the right
            /// </summary>
            Right
        };

        #endregion

    }

}
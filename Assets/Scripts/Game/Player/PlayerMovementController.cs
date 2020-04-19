using Gang1057.Ludiwuri.Game.World;
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
        /// <summary>
        /// The renderer used to show the player
        /// </summary>
        [SerializeField] private SpriteRenderer sr;
        /// <summary>
        /// Used to animate the player
        /// </summary>
        [SerializeField] private Animator anim;

#pragma warning restore 649

        /// <summary>
        /// The extend of the room in one direction
        /// </summary>
        private float roomConstraint;
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
        /// Allows to lock the player in place
        /// </summary>
        public bool Locked { get; set; }


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
        /// Indicates if the player can move
        /// </summary>
        private bool CanMove { get { return !Locked; } }

        /// <summary>
        /// The speed with which the player is currently moving
        /// </summary>
        private float Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
            }
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

                sr.flipX = value == Directions.Left;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when a new room is entered
        /// </summary>
        /// <param name="room">The room that was entered</param>
        public void OnRoomChange(Room room)
        {
            roomConstraint = (room.RoomWidth / 2) - 0.5f;
        }


        /// <summary>
        /// Called when the object is initialized
        /// </summary>
        private void Awake()
        {
            Speed = walkSpeed;
        }

        /// <summary>
        /// Called every frame
        /// </summary>
        private void Update()
        {
            // If the player can move

            if (CanMove)
            {
                // Update "Running" property

                bool running = Input.GetButton("Sprint");

                if (running != Running)
                    Running = running;

                // Move the player horizontally

                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, 0);
            }

            // If the player is moving

            if (Mathf.Abs(rb.velocity.x) > 0.1f)
            {
                // Update "FaceingDirection" property

                Directions faceingDirection = rb.velocity.x < 0 ? Directions.Left : Directions.Right;

                if (faceingDirection != FaceingDirection)
                    FaceingDirection = faceingDirection;
            }

            // Update animator

            anim.SetFloat("Speed", Speed);

            // Clamp player position

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -roomConstraint, roomConstraint),
                transform.position.y,
                0);
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
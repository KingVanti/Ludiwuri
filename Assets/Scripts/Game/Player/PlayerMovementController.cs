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
        /// Used to animate the player
        /// </summary>
        [SerializeField] private Animator anim;
        [SerializeField] private PlayerController controller;

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
        /// Backing field to <see cref="FaceingDirection"/>
        /// </summary>
        private Directions _faceingDirection = Directions.Right;
        private bool _locked;

        #endregion

        #region Properties

        /// <summary>
        /// Allows to lock the player in place
        /// </summary>
        public bool Locked
        {
            get { return _locked; }
            set
            {
                _locked = value;

                if (_locked)
                    rb.velocity = Vector2.zero;
            }
        }


        /// <summary>
        /// Indicates whether the player is currently running
        /// </summary>
        private bool Running
        {
            get { return _running; }
            set
            {
                if (value != _running)
                {
                    _running = value;

                    Speed = value ? runSpeed : walkSpeed;

                    if (value)
                        controller.candle.PutOut();
                }
            }
        }

        /// <summary>
        /// Indicates if the player can move
        /// </summary>
        private bool CanMove { get { return !Locked; } }

        /// <summary>
        /// The speed with which the player is currently moving
        /// </summary>
        private float Speed { get; set; } = 0;

        /// <summary>
        /// The direction in which the player is currently facing
        /// </summary>
        private Directions FaceingDirection
        {
            get { return _faceingDirection; }
            set
            {
                _faceingDirection = value;

                transform.GetChild(0).localScale = new Vector3(value == Directions.Left ? -1 : 1, 1, 1);
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
            roomConstraint = (room.RoomWidth / 2) - 0.25f;
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
            // Update "Running" property

            bool running = Input.GetButton("Sprint");

            if (running != Running)
                Running = running;

            float input = CanMove ? Input.GetAxis("Horizontal") : 0;

            // Move the player horizontally

            rb.velocity = new Vector2(input * Speed, 0);

            // If the player is moving

            if (Mathf.Abs(rb.velocity.x) > 0.1f)
            {
                // Update "FaceingDirection" property

                Directions faceingDirection = rb.velocity.x < 0 ? Directions.Left : Directions.Right;

                if (faceingDirection != FaceingDirection)
                    FaceingDirection = faceingDirection;
            }

            // Update animator

            if (input == 0)
                anim.SetInteger("MoveState", 0);
            else if (!Running)
                anim.SetInteger("MoveState", 1);
            else
                anim.SetInteger("MoveState", 2);

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
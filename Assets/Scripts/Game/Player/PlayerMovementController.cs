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
        /// The rigid-body used for moving the player
        /// </summary>
        [SerializeField] private Rigidbody2D rb;

#pragma warning restore 649

        #endregion

    }

}
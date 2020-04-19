using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Gang1057.Ludiwuri.Game.World
{

    public class LightSource : MonoBehaviour
    {

        #region Fields

        /// <summary>
        /// The source
        /// </summary>
        [SerializeField] protected Light2D lightSource;

        #endregion

        #region Properties
        /// <summary>
        /// Indicates whether the source is currently lit
        /// </summary>
        public bool Lit { get; protected set; } = true;


        #endregion

    }

}
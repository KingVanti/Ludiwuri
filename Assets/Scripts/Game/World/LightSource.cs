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
        private bool _lit = true;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether the source is currently lit
        /// </summary>
        public bool Lit
        {
            get { return _lit; }
            set
            {
                _lit = value;
                lightSource.enabled = value;
            }
        }

        public float Radius { get { return lightSource.pointLightOuterRadius * 0.75f; } }

        #endregion

    }

}
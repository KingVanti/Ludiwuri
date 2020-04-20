using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Gang1057.Ludiwuri.Game.World
{

    public class LightSource : MonoBehaviour
    {

        #region Fields

#pragma warning disable 649

        /// <summary>
        /// The source
        /// </summary>
        [SerializeField] private Light2D lightSource;
        [SerializeField] private Animator anim;

#pragma warning restore 649

        private bool _lit;

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
                anim.SetBool("Lit", value);
            }
        }

        public float Radius { get { return lightSource.pointLightOuterRadius * 0.5f; } }

        #endregion

        #region Methods

        private void Awake()
        {
            Lit = true;
        }

        #endregion

    }

}
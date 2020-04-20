using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Gang1057.Ludiwuri.Game.World
{

    public class LightSource : MonoBehaviour
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private float minMinBurnTime;
        [SerializeField] private float maxMinBurnTime;
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
                if (value != _lit)
                {
                    _lit = value;
                    lightSource.enabled = value;
                    anim.SetBool("Lit", value);

                    if (value)
                        StartCoroutine(FixedTime());
                    else
                    {
                        StopAllCoroutines();
                        FixedOn = false;
                    }
                }
            }
        }

        public bool FixedOn { get; private set; }

        public float Radius { get { return lightSource.pointLightOuterRadius * 0.5f; } }

        #endregion

        #region Methods

        private void Awake()
        {
            Lit = true;
        }

        private IEnumerator FixedTime()
        {
            FixedOn = true;
            yield return new WaitForSeconds(Random.Range(minMinBurnTime, maxMinBurnTime));
            FixedOn = false;
        }

        #endregion

    }

}
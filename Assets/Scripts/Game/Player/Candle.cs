using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Gang1057.Ludiwuri.Game.Player
{

    /// <summary>
    /// Controls the players candle
    /// </summary>
    public class Candle : MonoBehaviour
    {
        #region Fields

#pragma warning disable 649

        [SerializeField] private float minBurnTime;
        [SerializeField] private float maxBurnTime;
        [SerializeField] private float minRadius;
        [SerializeField] private float maxRadius;
        /// <summary>
        /// The players animator
        /// </summary>
        [SerializeField] private Animator anim;
        [SerializeField] private Light2D lightSource;
        [SerializeField] private PlayerController controller;

#pragma warning restore 649

        #endregion

        private bool _lit;

        #region Properties

        public bool Lit
        {
            get { return _lit; }
            private set
            {
                _lit = value;
                anim.SetBool("CandleLit", value);
                lightSource.enabled = value;

                controller.UpdateCurrentLightState();
                controller.UpdateInteractionPrompt();
            }
        }

        #endregion

        #region Methods

        public void Light()
        {
            Lit = true;
            GlobalSoundPlayer.Instance.PlaySound("Candle_light");

            StopAllCoroutines();
            StartCoroutine(FadeOut());
        }

        public void PutOut()
        {
            Lit = false;

            StopAllCoroutines();
        }

        private IEnumerator FadeOut()
        {
            float burnTime = Random.Range(minBurnTime, maxBurnTime);

            float t = 0;

            while (t < 1)
            {
                t = Mathf.MoveTowards(t, 1, Time.deltaTime / burnTime);
                lightSource.pointLightOuterRadius = Mathf.Lerp(maxRadius, minRadius, t);
                yield return null;
            }

            PutOut();
        }

        #endregion

    }

}
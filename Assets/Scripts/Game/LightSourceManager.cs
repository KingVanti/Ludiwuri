using Gang1057.Ludiwuri.Game.World;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gang1057.Ludiwuri.Game
{

    public class LightSourceManager : MonoBehaviour
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private float startMinWaitTime;
        [SerializeField] private float startMaxWaitTime;
        [SerializeField] private float endMinWaitTime;
        [SerializeField] private float endMaxWaitTime;
        [SerializeField] private GameManager gameManager;

#pragma warning restore 649

        private LightSource[] sources = new LightSource[0];

        #endregion

        #region Methods

        public void Initialize()
        {
            sources = RoomManager.Instance.GetAllLightSource();

            StartCoroutine(BlowOutCandles());
        }

        private IEnumerator BlowOutCandles()
        {
            while (true)
            {
                yield return new WaitForSeconds(
                    Random.Range(
                        Mathf.Lerp(startMinWaitTime, startMaxWaitTime, gameManager.GameProgressionT),
                        Mathf.Lerp(endMinWaitTime, endMaxWaitTime, gameManager.GameProgressionT)
                        ));

                IEnumerable<LightSource> litSources = sources.Where(l => l.Lit && !l.FixedOn);

                if (litSources.Count() > 0)
                {

                    LightSource nextSource = litSources.ElementAt(Random.Range(0, litSources.Count()));

                    nextSource.Lit = false;
                }
            }
        }

        #endregion

    }

}
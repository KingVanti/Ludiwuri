using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gang1057.Ludiwuri.Game.UI
{

    public class SanityBar : MonoBehaviour
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private Slider slider;
        [SerializeField] private Image fillImage;
        [SerializeField] private Color emptyColor;
        [SerializeField] private Color fullColor;

#pragma warning restore 649

        #endregion

        #region Methods

        public void OnSanityChange(float sanity)
        {
            slider.value = sanity;

            fillImage.color = Color.Lerp(emptyColor, fullColor, sanity / 100);
        }

        #endregion

    }

}
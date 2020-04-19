using UnityEngine;
using UnityEngine.UI;

namespace Gang1057.Ludiwuri.Game.UI
{

    /// <summary>
    /// Displays the lamps health
    /// </summary>
    public class CandleHealthBar : MonoBehaviour
    {

        #region Fields

#pragma warning disable 649

        /// <summary>
        /// The slider used to display the health
        /// </summary>
        [SerializeField] private Slider slider;

#pragma warning restore 649

        #endregion

        #region Methods

        /// <summary>
        /// Displays the given health value
        /// </summary>
        /// <param name="health">The value</param>
        public void DisplayHealth(int health)
        {
            slider.value = health;
        }

        #endregion

    }

}
using System.Collections;
using TMPro;
using UnityEngine;

namespace Gang1057.Ludiwuri.Game
{

    /// <summary>
    /// Manages the Game scene
    /// </summary>
    public class GameManager : MonoBehaviour, ISceneManager
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private int gameSeconds;
        [SerializeField] private TextMeshProUGUI winTimeText;

#pragma warning restore 649

        private int _secondsToWin;

        #endregion

        #region Properties

        public int SecondsToWin
        {
            get { return _secondsToWin; }
            set
            {
                _secondsToWin = value;

                winTimeText.text = $"{(value / 60).ToString("00")}:{(value % 60).ToString("00")}";
            }
        }

        #endregion

        #region Methods

        private void Awake()
        {
            SecondsToWin = gameSeconds;

            StartCoroutine(TickTime());
        }

        private IEnumerator TickTime()
        {
            while (SecondsToWin > 0)
            {
                yield return new WaitForSeconds(1);
                SecondsToWin--;
            }

            // TODO: Trigger Win
        }

        #endregion

    }

}
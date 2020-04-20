using Gang1057.Ludiwuri.Game.World;
using Gang1057.Ludiwuri.Game.World.Collectibles;
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
        [SerializeField] private int matchBoxCount;
        [SerializeField] private GameObject matchBoxPrefab;
        [SerializeField] private TextMeshProUGUI winTimeText;
        [SerializeField] private RoomManager roomManager;
        [SerializeField] private LightSourceManager lightSourceManager;

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

        public float GameProgressionT { get { return SecondsToWin / (float)gameSeconds; } }

        #endregion

        #region Methods

        private void Awake()
        {
            roomManager.Initialize();
            lightSourceManager.Initialize();

            SpawnMatchBoxes();

            SecondsToWin = gameSeconds;

            StartCoroutine(TickTime());
        }

        private void SpawnMatchBoxes()
        {
            for (int i = 0; i < matchBoxCount; i++)
            {
                MatchBox matchBox = Instantiate(matchBoxPrefab).GetComponent<MatchBox>();

                RoomManager.Instance.Relocate(matchBox);
            }
        }

        private IEnumerator TickTime()
        {
            while (SecondsToWin > 0)
            {
                yield return new WaitForSeconds(1);
                SecondsToWin--;
            }

            PlayerPrefs.SetInt("GameState", 1);
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScreen");
        }

        #endregion

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gang1057.Ludiwuri.EndScreen
{

    public class TitleManager : MonoBehaviour
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private GameObject gameOverTitle;
        [SerializeField] private GameObject winTitle;

#pragma warning restore 649

        #endregion

        #region Methods

        private void Awake()
        {
            int gameState = PlayerPrefs.GetInt("GameState");

            if(gameState == 0)
            {
                gameOverTitle.SetActive(true);
            }
            else if (gameState == 1)
            {
                winTitle.SetActive(true);
            }
        }

        #endregion

    }

}
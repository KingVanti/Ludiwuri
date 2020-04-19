using TMPro;
using UnityEngine;

public class DeathCountdownText : MonoBehaviour
{

    #region Fields

#pragma warning disable 649

    [SerializeField] private TextMeshProUGUI text;

#pragma warning restore 649

    #endregion

    #region Methods

    public void SetCountdownTime(int? time)
    {
        if (time.HasValue)
            text.text = $"{time.Value} second{(time.Value != 1 ? "s" : "")}";
        else
            text.text = "";
    }

    #endregion

}

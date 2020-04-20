using UnityEngine;

namespace Gang1057.Ludiwuri.Game.Player
{

    public class StepPlayer : MonoBehaviour
    {

        public void Step()
        {
            GlobalSoundPlayer.Instance.PlaySound($"Step_{Random.Range(1, 3)}", 0.9f, 1.1f);
        }

    }

}
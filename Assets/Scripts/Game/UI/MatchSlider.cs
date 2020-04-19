using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gang1057.Ludiwuri.Game.UI
{

    /// <summary>
    /// Used to detect the players sliding action
    /// </summary>
    public class MatchSlider : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {

        #region Fields

        /// <summary>
        /// Called when a strike occurs
        /// </summary>
        public UnityEvent onStrike;

#pragma warning disable 649

        /// <summary>
        /// The minimum distance the cursor needs to move in order to count towards a strike
        /// </summary>
        [SerializeField] private float minMoveDelta;
        /// <summary>
        /// The distance the cursor needs to move to register a strike
        /// </summary>
        [SerializeField] private float strikeDistance;

#pragma warning restore 649

        private bool onMatchBox;
        /// <summary>
        /// The value the slider started at
        /// </summary>
        private Vector2 startPosition;
        /// <summary>
        /// The previous value
        /// </summary>
        private Vector2 prevValue;
        /// <summary>
        /// The previous distance
        /// </summary>
        private float prevDistance;

        #endregion

        #region Methods

        /// <summary>
        /// Called when the slider is clicked
        /// </summary>
        public void OnPointerDown(PointerEventData eventData)
        {
            if (onMatchBox)
                StartAtCurrentPosition();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onMatchBox = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onMatchBox = false;
        }

        /// <summary>
        /// Called when the sliders value changes
        /// </summary>
        /// <param name="mousePos">The sliders new value</param>
        private void OnMousePosChanged(Vector2 mousePos)
        {
            float delta = Vector2.Distance(mousePos, prevValue);
            float distance = Vector2.Distance(mousePos, startPosition);

            // If the cursor moved too little

            if (delta < minMoveDelta)
            {
                // Start again

                StartAtCurrentPosition();
            }

            // If the cursor moved in the wrong direction

            else if (distance < prevDistance)
            {
                // Start again

                StartAtCurrentPosition();
            }

            // If the cursor moved enough for a strike

            else if (distance >= strikeDistance)
            {
                onStrike.Invoke();
            }

            // If the cursor moved correctly, but not enough for a strike

            else
            {
                prevValue = mousePos;
                prevDistance = distance;
            }
        }


        private void Update()
        {
            if (onMatchBox && Input.GetMouseButton(0))
                OnMousePosChanged(Input.mousePosition);
        }

        private void StartAtCurrentPosition()
        {
            startPosition = Input.mousePosition;
            prevValue = startPosition;
            prevDistance = 0;
        }

        #endregion

    }

}
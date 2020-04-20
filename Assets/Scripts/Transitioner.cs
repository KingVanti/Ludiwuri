using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Gang1057.Ludiwuri
{

    /// <summary>
    /// Transitions between scenes
    /// </summary>
    public class Transitioner : MonoBehaviour
    {

        #region Static Properties

        /// <summary>
        /// The static singleton instance
        /// </summary>
        public static Transitioner Instance { get; private set; }

        #endregion

        #region Fields

#pragma warning disable 649

        [SerializeField] private float fadeTime;
        [SerializeField] private Image fadeImage;

#pragma warning restore 649

        private Coroutine transitionRoutine;

        #endregion

        #region Properties

        /// <summary>
        /// The alpha value of the <see cref="fadeImage"/>
        /// </summary>
        private float Alpha { get { return fadeImage.color.a; } set { fadeImage.color = new Color(0, 0, 0, value); } }

        #endregion

        #region Methods

        /// <summary>
        /// Transitions to a scene
        /// </summary>
        /// <param name="sceneIndex">The index of the scene that should be transitioned to</param>
        public void TransitionTo(int sceneIndex, bool cancel = false)
        {
            if (transitionRoutine != null && cancel)
            {
                StopAllCoroutines();
                transitionRoutine = null;
            }

            if (transitionRoutine == null)
                transitionRoutine = StartCoroutine(TransitionWithAnimation(sceneIndex));
        }

        /// <summary>
        /// Makes the screen black
        /// </summary>
        /// <returns>The fade routine</returns>
        public Coroutine FadeToBlack()
        {
            StopAllCoroutines();
            return StartCoroutine(FadeTo(1));
        }

        /// <summary>
        /// Makes the scene visible
        /// </summary>
        /// <returns>The fade routine</returns>
        public Coroutine FadeToScene()
        {
            StopAllCoroutines();
            return StartCoroutine(FadeTo(0));
        }


        private void Awake()
        {
            // Check if there no singleton instance yet

            if (Instance == null)
            {

                // If there isnt, make this instance the singleton instance

                DontDestroyOnLoad(gameObject);
                Instance = this;

                IEnumerable<ITransitionAware> transitionAwareObjects = FindObjectsOfType<MonoBehaviour>().OfType<ITransitionAware>();


                foreach (ITransitionAware transitionAwareObject in transitionAwareObjects)
                    transitionAwareObject.OnSceneLoad();


                foreach (ITransitionAware transitionAwareObject in transitionAwareObjects)
                    transitionAwareObject.OnTransitionCompleted();
            }

            // If there is already a singleton instance

            else

                // Destroy this instance

                Destroy(gameObject);
        }

        /// <summary>
        /// Transitions to a scene with a fade animation
        /// </summary>
        /// <param name="sceneIndex">The index of the scene that should be transitioned to</param>
        /// <returns>An <see cref="IEnumerator"/> that can be used for a <see cref="Coroutine"/></returns>
        private IEnumerator TransitionWithAnimation(int sceneIndex)
        {
            IEnumerable<ITransitionAware> transitionAwareObjects = FindObjectsOfType<MonoBehaviour>().OfType<ITransitionAware>();

            // If a scenemanager was found, notify of transition start

            foreach (ITransitionAware transitionAwareObject in transitionAwareObjects)
                transitionAwareObject.OnTransitionStarted();

            // Fade in image

            yield return FadeTo(1);

            // If a scenemanager was found, notify of scene unload

            foreach (ITransitionAware transitionAwareObject in transitionAwareObjects)
                transitionAwareObject.OnSceneUnload();

            // Stop all currently playing sounds

            if (GlobalSoundPlayer.Instance != null)
                GlobalSoundPlayer.Instance.StopAllSounds();

            // Load next scene

            AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
            yield return new WaitUntil(() => operation.isDone);

            transitionAwareObjects = FindObjectsOfType<MonoBehaviour>().OfType<ITransitionAware>();

            // If a scenemanager was found, notify of scene load

            foreach (ITransitionAware transitionAwareObject in transitionAwareObjects)
                transitionAwareObject.OnSceneLoad();

            // Fade out image

            yield return FadeTo(0);

            // If a scenemanager was found, notify of transition completion

            foreach (ITransitionAware transitionAwareObject in transitionAwareObjects)
                transitionAwareObject.OnTransitionCompleted();

            transitionRoutine = null;
        }

        /// <summary>
        /// Fades <see cref="Alpha"/> to a specific value over <see cref="fadeTime"/>
        /// </summary>
        /// <param name="goalAlpha">The alpha value that should be faded to</param>
        /// <returns>An <see cref="IEnumerator"/> that can be used for a <see cref="Coroutine"/></returns>
        private IEnumerator FadeTo(float goalAlpha)
        {
            float t = 0;
            float startAlpha = Alpha;

            while (t < 1)
            {
                // Move t

                t = Mathf.MoveTowards(t, 1, Time.deltaTime / fadeTime);

                // Lerp alpha by t

                Alpha = Mathf.SmoothStep(startAlpha, goalAlpha, t);
                yield return null;
            }
        }

        #endregion

    }

}
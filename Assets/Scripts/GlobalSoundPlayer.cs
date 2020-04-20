using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gang1057.Nyctophobia
{

    /// <summary>
    /// Plays global sounds
    /// </summary>
    public class GlobalSoundPlayer : MonoBehaviour
    {

        #region Static Properties

        /// <summary>
        /// The static singleton instance
        /// </summary>
        public static GlobalSoundPlayer Instance { get; private set; }

        #endregion

        #region Fields

#pragma warning disable 649

        [SerializeField] private AudioClip[] clips;
        [SerializeField] private int sourcePoolCount;

#pragma warning restore 649

        private readonly Dictionary<string, AudioClip> registeredClips = new Dictionary<string, AudioClip>();
        private readonly Queue<AudioSource> idleSources = new Queue<AudioSource>();
        private readonly List<AudioSource> activeSources = new List<AudioSource>();

        #endregion

        #region Methods

        public void PlaySound(string soundName, float minPitch, float maxPitch)
        {
            PlaySound(soundName, Random.Range(minPitch, maxPitch));
        }

        /// <summary>
        /// Plays a sound
        /// </summary>
        /// <param name="soundName">The name of the sound that should be played</param>
        public void PlaySound(string soundName, float pitch = 1)
        {
            // Check if a clip with that name exists

            if (registeredClips.ContainsKey(soundName))
            {

                // Get the clip

                AudioClip clip = registeredClips[soundName];

                // Check if there are any idle audio sources available

                if (idleSources.Count > 0)
                {

                    // Get a source

                    AudioSource source = idleSources.Dequeue();
                    source.pitch = pitch;

                    // Add source to active sources

                    activeSources.Add(source);

                    // Set clip and pitch

                    source.clip = clip;

                    // Enable source and play

                    source.enabled = true;
                    source.Play();

                    // Wait for source to finish on seperate thread

                    StartCoroutine(WaitForSourceToFinish(source));
                }

                // If not, throw an exception

                else
                    throw new System.Exception("Cant play sound, all AudioSources are busy. Increase pool size!");
            }

            // If not, throw an exception

            else
                throw new System.Exception($"Sound \"{soundName}\" is not registered in this SoundPlayer!");
        }

        /// <summary>
        /// Stops all sounds that are currently beeing played
        /// </summary>
        public void StopAllSounds()
        {
            // Stop all wait routines

            StopAllCoroutines();

            // Go through each source

            foreach (AudioSource source in activeSources.ToArray())
            {
                // Stop the source

                source.Stop();

                // Add back to queue

                activeSources.Remove(source);
                idleSources.Enqueue(source);
            }
        }


        private void Awake()
        {
            // Initialize clips and sources

            RegisterClips();
            AddSources();

            // This instance becomes the static instance

            Instance = this;
        }

        /// <summary>
        /// Registeres the clips for this <see cref="GlobalSoundPlayer"/> by their name
        /// </summary>
        private void RegisterClips()
        {
            foreach (AudioClip clip in clips)
                registeredClips.Add(clip.name, clip);
        }

        /// <summary>
        /// Adds a pool of <see cref="AudioSource"/>s to the gameobejct
        /// </summary>
        private void AddSources()
        {
            // Add as many sources as defined in sourcePoolCount

            for (int i = 0; i < sourcePoolCount; i++)
            {
                // Add source and disable it

                AudioSource source = gameObject.AddComponent<AudioSource>();
                source.enabled = false;

                // Add to idle queue

                idleSources.Enqueue(source);
            }
        }

        /// <summary>
        /// Waits for a source to stop playing and adds it back to <see cref="idleSources"/>
        /// </summary>
        /// <param name="source">The source that should be waited for</param>
        /// <returns>An <see cref="IEnumerator"/> that can be used in a Coroutine</returns>
        private IEnumerator WaitForSourceToFinish(AudioSource source)
        {
            // Wait until source is done playing

            while (source.isPlaying)
                yield return null;

            // Disable source and add to idle sources

            source.enabled = false;
            idleSources.Enqueue(source);

            // Remove source from active sources

            activeSources.Remove(source);
        }

        #endregion

    }

}
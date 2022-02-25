using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace CafofoStudio
{    
    [System.Serializable]
    public class SoundSubElementLoop : ISoundSubElement
    {
        [SerializeField] private bool isAditive = true;

        [SerializeField] private List<AudioClip> audioClips;

        /// <summary>
        /// Created AudioSources.
        /// </summary>
        private List<AudioSource> loopAudioSources;

        private Dictionary<AudioSource, bool> muteOnNextUpdate = new Dictionary<AudioSource, bool>();

        /// <summary>
        /// Creates a separate AudioSource for each looping clip.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="outputMixer"></param>
        public void InitializeAudioSources(GameObject parent, AudioMixerGroup outputMixer)
        {
            loopAudioSources = new List<AudioSource>();
            foreach (AudioClip audioclip in audioClips)
            {
                AudioSource tempAudioSource = parent.AddComponent<AudioSource>();
                tempAudioSource.clip = audioclip;
                tempAudioSource.loop = true;
                tempAudioSource.playOnAwake = false;
                tempAudioSource.outputAudioMixerGroup = outputMixer;
                loopAudioSources.Add(tempAudioSource);
            }
        }

        /// <summary>
        /// Calculates the volume of each audiosource based on the intensity value.
        /// </summary>
        /// <param name="intensity">The intensity, from 0.0 to 1.0.</param>
        /// <param name="volumeMultiplier">The volume multiplier, from 0.0 to 1.0.</param>
        public void CalculateIntensity(float intensity, float volumeMultiplier)
        {
            //Do not play that element when the intensity is 0.
            if (intensity == 0f)
            {
                AudioSource currAudioSource;
                for (int i = 0; i < loopAudioSources.Count; i++)
                {
                    currAudioSource = loopAudioSources[i];
                    currAudioSource.volume = 0;
                    if (ShouldAddAudioSourceToStopList(currAudioSource))
                    {
                        muteOnNextUpdate[currAudioSource] = false;
                    }
                }
                return;
            }

            if(isAditive)
            {
                CalculateAditiveIntensity(intensity, volumeMultiplier);
            } else
            {
                CalculateCrossfadeIntensity(intensity, volumeMultiplier);
            }
        }

        private void CalculateAditiveIntensity(float intensity, float volumeMultiplier)
        {
            float normalizedVol = intensity * loopAudioSources.Count;
            float volume = 0f;
            AudioSource currAudioSource;
            for (int i = 0; i < loopAudioSources.Count; i++)
            {
                currAudioSource = loopAudioSources[i];
                volume = Mathf.Clamp01(normalizedVol - i) * volumeMultiplier;
                currAudioSource.volume = volume;

                if (ShouldAddAudioSourceToStopList(currAudioSource))
                {
                    muteOnNextUpdate[currAudioSource] = false;
                }
                else if (currAudioSource.volume != 0)
                {
                    muteOnNextUpdate.Remove(currAudioSource);
                    if (!currAudioSource.isPlaying)
                    {
                        currAudioSource.Play();
                    }
                }
            }
        }

        private void CalculateCrossfadeIntensity(float intensity, float volumeMultiplier)
        {
            float periodLength = 1f / (2 * loopAudioSources.Count - 1);

            float gapStart;
            float cv;
            AudioSource currAudioSource;

            for (int i = 0; i < loopAudioSources.Count; i++)
            {
                currAudioSource = loopAudioSources[i];
                gapStart = (i * 2 * periodLength) - periodLength;
                cv = Mathf.Clamp01(CalculateCrossfade(periodLength, intensity - gapStart)) * volumeMultiplier;
                currAudioSource.volume = cv;
                
                if(ShouldAddAudioSourceToStopList(currAudioSource))
                {
                    muteOnNextUpdate[currAudioSource] = false;
                }
                else if(currAudioSource.volume != 0)
                {
                    muteOnNextUpdate.Remove(currAudioSource);

                    if (!currAudioSource.isPlaying)
                    {
                        currAudioSource.Play();
                    }
                }
            }
        }

        private bool ShouldAddAudioSourceToStopList(AudioSource a)
        {
            return a.volume == 0 && !muteOnNextUpdate.ContainsKey(a);
        }

        public void PerformCleanupPass()
        {
            List<AudioSource> keys = new List<AudioSource> (muteOnNextUpdate.Keys);
            foreach (AudioSource removeCandidate in keys)
            {
                if(muteOnNextUpdate[removeCandidate])
                {
                    removeCandidate.clip.UnloadAudioData();
                    muteOnNextUpdate.Remove(removeCandidate);
                }
                else
                {
                    muteOnNextUpdate[removeCandidate] = true;
                }
            }
        }

        private float CalculateCrossfade(float periodLength, float intensity)
        {
            if(intensity < periodLength)
            {
                return intensity / periodLength;
            }
            else if(intensity > 2*periodLength)
            {
                return 1 - (intensity - periodLength * 2) / periodLength;
            }
            else
            {
                return 1f;
            }
        }

        /// <summary>
        /// Overrides the default AudioMixerGroup for all AudioSources.
        /// </summary>
        /// <param name="overrideOutputMixer">The new AudioMixerGroup. A null value restores to the default group used by Unity.</param>
        public void SetOutputMixerGroup(AudioMixerGroup overrideOutputMixer)
        {
            if (loopAudioSources != null)
            {
                for (int i = 0; i < loopAudioSources.Count; i++)
                {
                    loopAudioSources[i].outputAudioMixerGroup = overrideOutputMixer;
                }
            }
        }

        /// <summary>
        /// Starts playing all AudioSources.
        /// </summary>
        public void Play()
        {
            if (loopAudioSources != null)
            {
                foreach (AudioSource audioSource in loopAudioSources)
                {
                    if (!audioSource.mute)
                    {
                        audioSource.Play();
                    }
                }
            }
        }

        /// <summary>
        /// Stops playing all AudioSources.
        /// </summary>
        public void Stop()
        {
            if (loopAudioSources != null)
            {
                foreach (AudioSource audioSource in loopAudioSources)
                {
                    audioSource.Stop();
                }
            }
        }
    }
}

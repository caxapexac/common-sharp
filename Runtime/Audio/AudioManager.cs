using System;
using UnityEngine;
using UnityEngine.Audio;


namespace Caxapexac.Common.Sharp.Runtime.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        public AudioMixerGroup MixerGroup;

        public Sound[] Sounds;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            foreach (Sound s in Sounds)
            {
                s.Source = gameObject.AddComponent<AudioSource>();
                s.Source.clip = s.Clip;
                s.Source.loop = s.Loop;

                s.Source.outputAudioMixerGroup = MixerGroup;
            }
        }

        public void Play(string sound)
        {
            Sound s = Array.Find(Sounds, item => item.Name == sound);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            s.Source.volume = s.Volume * (1f + UnityEngine.Random.Range(-s.VolumeVariance / 2f, s.VolumeVariance / 2f));
            s.Source.pitch = s.Pitch * (1f + UnityEngine.Random.Range(-s.PitchVariance / 2f, s.PitchVariance / 2f));

            s.Source.Play();
        }

        public void Stop(string sound)
        {
            Sound s = Array.Find(Sounds, item => item.Name == sound);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            s.Source.Stop();
        }
    }
}
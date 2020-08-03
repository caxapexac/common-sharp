using Caxapexac.Common.Sharp.Runtime.Patterns;
using Caxapexac.Common.Sharp.Runtime.Patterns.Singleton;
using UnityEngine;


namespace Caxapexac.Common.Sharp.Runtime.Audio
{
    public class SfxPlayer : Singleton<SfxPlayer>
    {
        public AudioSource audioPrefab2D;
        public AudioSource audioPrefab3D;

        public void Play2D(AudioClip audioClip)
        {
            AudioSource audioSource = Instantiate(audioPrefab2D, transform);
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public void Play3D(AudioClip audioClip, Vector3 position)
        {
            AudioSource audioSource = Instantiate(audioPrefab3D, position, Quaternion.identity, transform);
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
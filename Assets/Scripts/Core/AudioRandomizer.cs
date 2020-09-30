using UnityEngine;

namespace RPG.Core
{
    public class AudioRandomizer : MonoBehaviour
    {
        [SerializeField] AudioClip[] audioClips = null;

        public void PlayRandomAudioClip()
        {
            if (audioClips != null)
            {
                int index = Random.Range(0, audioClips.Length);
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.clip = audioClips[index];
                audioSource.Play();
            }
        }
        
    } 
}
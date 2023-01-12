using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lee
{
    [RequireComponent(typeof(AudioSource))]

    public class SoundSystem : MonoBehaviour
    {
        private AudioSource aud;

        private void Awake() 
        {
            aud = GetComponent<AudioSource>();
        }

        ///<summary>
        ///波音樂
        ///</summary>
        ///<param name = "sound">要撥放的音樂</param>
        public void PlaySound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
        }
    }
}



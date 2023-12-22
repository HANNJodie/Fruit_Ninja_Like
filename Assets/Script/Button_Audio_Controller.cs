using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Audio_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip _HoverSound;
    public AudioClip _ClicSound;
    public AudioSource _audioSource;

    public void PlayHoverSound()
    {
        _audioSource.clip = _HoverSound;
        _audioSource.Play();
    }
    public void PlayClicSound()
    {
        _audioSource.clip = _ClicSound;
        _audioSource.Play();
    }

}

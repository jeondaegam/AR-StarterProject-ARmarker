using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    // Controls the audio on button press

    public Button buttonAudio;
    public AudioSource audioSource;

    void Start()
    {
        buttonAudio.onClick.AddListener(TogglePlayAudio);
    }

    void Update()
    {
        if (audioSource == null)
        {
            GameObject modelObject = GameObject.FindWithTag("ModelObject");

            if (modelObject)
            {
                audioSource = modelObject.GetComponentInChildren<AudioSource>();
            }
        }

    }

    public void TogglePlayAudio()
    {
        if (audioSource)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            else
            {
                audioSource.Play();
            }
        } else
        {
            Debug.Log("Audiosource is not assigned!");
        }
    }
}

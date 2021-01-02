using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSoundPlayNew : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio1;
    [SerializeField]
    private AudioSource audio2;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (audio1.isPlaying)
            {
                //audio1.Stop();
                audio2.Play();
                StartCoroutine(TransitionAudio1ToAudio2Coroutine());
            }
            else
            {

                audio2.Stop();
                audio1.Play();
                //StartCoroutine(TransitionCoroutine());
            }
        }
    }

    IEnumerator TransitionAudio1ToAudio2Coroutine()
    {
        float progress = 0.0f;
        // loop until we reach the end of the linear interpolation
        while (progress < 0.1f)
        {
            progress += Time.unscaledDeltaTime / 20.0f;
            audio1.volume = 0.1f - progress;
            audio2.volume = progress;
            yield return null;
        }
    }
}

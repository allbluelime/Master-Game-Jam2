using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToChasedAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource Background;
    [SerializeField]
    private AudioSource Chased;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private float fadingTime = 1f;
    private bool isPlaying = false;
    private int foundTargets = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    public void ChangeAudioSource(bool isPlayerThere)
    {

        if (isPlayerThere == true)
        {

            if (isPlaying == false)
            {

                isPlaying = true;
                StartCoroutine(FadeAudio(Background, Chased, fadingTime));
            }
        }


       
        if (isPlaying == true)
        {
            isPlaying = false;
            StartCoroutine(FadeAudio(Chased, Background, fadingTime));
        }

    }



    public IEnumerator FadeAudio(AudioSource firstAudioSource, AudioSource secondAudioSource, float FadeTime)
    {
        float startVolume = firstAudioSource.volume;
        while (firstAudioSource.volume > 0)
        {
            firstAudioSource.volume -= startVolume * Time.deltaTime / FadeTime;

        }
        firstAudioSource.Stop();
        yield return new WaitForSeconds(FadeTime);
        secondAudioSource.Play();
        secondAudioSource.volume = 0f;
        while (secondAudioSource.volume < 1)
        {
            secondAudioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }

    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class ClickSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;

    private Button button {get { return GetComponent<Button>(); }}
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    private void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        button.onClick.AddListener(() => PlaySound());
    }
    void PlaySound()
    {
        source.PlayOneShot(sound);
    }
}

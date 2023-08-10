using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioSource bgm;
    [SerializeField]
    private AudioSource fx;
    [SerializeField]
    private List<AudioClip> bgmList;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayOneShot(AudioClip clip)
    {
        instance.fx.PlayOneShot(clip);
    }
}

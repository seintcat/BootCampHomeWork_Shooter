using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxHandler : MonoBehaviour
{
    [SerializeField]
    private float time;
    [SerializeField]
    private AudioClip audioClip;

    public static bool playerDeath = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!playerDeath && audioClip != null)
        {
            AudioManager.PlayOneShot(audioClip);
        }
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

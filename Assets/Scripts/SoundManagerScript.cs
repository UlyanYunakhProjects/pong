using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    private static AudioClip wallHit;
    private static AudioClip paddleHit;
    private static AudioClip gateHit;

    private static AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        wallHit = Resources.Load<AudioClip>("wallHit");
        paddleHit = Resources.Load<AudioClip>("paddleHit");
        gateHit = Resources.Load<AudioClip>("gateHit");

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayWallHit()
    {
        source.PlayOneShot(wallHit);
    }

    public static void PlayPaddleHit()
    {
        source.PlayOneShot(paddleHit);
    }

    public static void PlayGateHit()
    {
        source.PlayOneShot(gateHit);
    }
}

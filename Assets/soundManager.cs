using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static AudioClip playerHitSound,healingSound;
    static AudioSource asr;
    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        healingSound = Resources.Load<AudioClip>("health");
        asr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip){
        switch(clip){
             case "playerHit":
                asr.PlayOneShot(playerHitSound);
                break;
             case "health":
                asr.PlayOneShot(healingSound);
                break;   
            }
        }
}

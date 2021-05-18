using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDoorSound : MonoBehaviour
{
    private AudioSource audiosource;
    [SerializeField]
    private AudioClip openSound;
    [SerializeField]
    private AudioClip closeSound;
    [SerializeField]
    private AudioClip slamSound;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }


    public void PlayOpenSound()
    {
        audiosource.clip = openSound;
        audiosource.Play();
    }

    public void PlayCloseSound()
    {
        audiosource.clip = closeSound;
        audiosource.Play();
    }

    public void PlaySlamSound()
    {
        audiosource.clip = slamSound;
        audiosource.Play();
    }


}
 

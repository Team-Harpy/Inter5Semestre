using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDoorSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audiosource;
    [SerializeField]
    private AudioClip openSound;
    [SerializeField]
    private AudioClip closeSound;
   

 


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

    


}
 

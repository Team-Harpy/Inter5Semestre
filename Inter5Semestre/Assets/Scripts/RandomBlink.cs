using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBlink : MonoBehaviour
{
    private Animator anim;
    public int chance;
    private float timer;
    private VolumeManager volume;
    private SpriteRenderer sr;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        volume = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            int sorteio = Random.Range(0, 100);
            if (sorteio <= chance)
            {
                anim.SetTrigger("blink");
            }
            timer = 0;
        }

        if (volume.emAlucinacao)
        {
            sr.enabled = true;
        }
        else if (!volume.emAlucinacao)
        {
            sr.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    private InputManager move;
    public AudioClip[] Footsteps;
    private PlayerController PJ;
    public AudioSource Passos;

    // Start is called before the first frame update
    void Start()
    {
        move = InputManager.Instance;
        PJ = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PJ.groundedPlayer && (move.GetPlayerMovement().x != 0 || move.GetPlayerMovement().y != 0) && Passos.isPlaying == false)
        {
            Passos.clip = Footsteps[Random.Range(0, Footsteps.Length)];
            Passos.Play();
            Debug.Log("andou");
        }
    }
}

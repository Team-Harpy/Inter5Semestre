using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeixaLanterna : Interactable
{
    private bool lanternaDown;
    private PlayerController player;
    public GameObject lanternaMesa;
    public MeshRenderer lanternaPlayerMesh;

    private void Start()
    {
        lanternaDown = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public override void Interact()
    {
        if (!lanternaDown)
        {
            player.hasFlashlight = false;
            lanternaPlayerMesh.enabled = false;
            player.flashlight.enabled = false;
            lanternaMesa.SetActive(true);
            lanternaDown = true;
        }
        else if (lanternaMesa)
        {
            player.hasFlashlight = true;
            lanternaPlayerMesh.enabled = true;
            lanternaMesa.SetActive(false);
            lanternaDown = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private void Update()
    {
        transform.LookAt(player.transform);
    }
}

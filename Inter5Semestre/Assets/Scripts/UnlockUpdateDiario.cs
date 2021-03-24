using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockUpdateDiario : MonoBehaviour
{
    [SerializeField]
    private GameObject atualizacao;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            atualizacao.SetActive(true);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryObjectiveInteract : Interactable
{
    [SerializeField]
    private Diario diario;
    [SerializeField]
    private string nomeObjetivo;
    // Start is called before the first frame update
    public override void Interact()
    {
        diario.AddSecondaryObjective(nomeObjetivo);
    }
}

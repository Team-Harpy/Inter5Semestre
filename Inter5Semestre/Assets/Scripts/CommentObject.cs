using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentObject : MonoBehaviour
{
    private float time;
    private float timeReset;
    [SerializeField]
    private float timeToReact;
    [SerializeField]
    private float cooldownReset;
    private bool cooldown = false;
    public DialogueBase dialogue;

    private void Update()
    {
        if (cooldown)
        {
            timeReset += Time.deltaTime;

            if (timeReset >= cooldownReset)
            {
                time = 0;
                timeReset = 0;
                cooldown = false;
            }
        }

        //Debug.Log(time);
    }

    public void Comment()
    {
        cooldown = true;
        time += Time.deltaTime;
        if (time >= timeToReact)
        {
            DialogueManager.instance.EnqueueDialogue(dialogue);
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}

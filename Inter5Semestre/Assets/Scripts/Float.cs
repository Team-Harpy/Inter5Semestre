using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{

    public Vector3 moveDirection;
    public float moveDistance;
    public float moveSpeed;

    private Vector3 startPosition;

    public bool Rotate;
    public float ValorRot;

    // Start is called before the first frame update
    void Start()
    {

        startPosition = gameObject.transform.position;

    

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + moveDirection * (moveDistance * Mathf.Sin(Time.time * moveSpeed));

        if (Rotate)
        {
            transform.Rotate(0, 0, ValorRot * Time.deltaTime);
        }
    }
}

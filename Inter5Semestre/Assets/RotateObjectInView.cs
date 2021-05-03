using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectInView : MonoBehaviour
{
    public float RotationSpeed = 5;
    InputManager input_;
    [SerializeField]
    LockCamera lockCamera;

    // Update is called once per frame

    private void Start()
    {
        input_ = InputManager.Instance;
       

    }
    void Update()
    {
        if (input_.PlayerMovingObject())
        {
            transform.Rotate(0, -(input_.GetMouseDelta().x * RotationSpeed * Time.deltaTime), (input_.GetMouseDelta().y * RotationSpeed * Time.deltaTime), Space.World);
        }

        if (input_.ExitLock())
        {
            lockCamera.UnlockPlayerCamera();
            this.gameObject.transform.localRotation = Quaternion.identity;
            this.gameObject.SetActive(false);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAim : MonoBehaviour
{
    public float turnSpeed = 15f;
    Camera turnCamera;
    // Start is called before the first frame update
    void Start()
    {
        turnCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yaw = turnCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yaw, 0), turnSpeed * Time.fixedDeltaTime);
    }
}

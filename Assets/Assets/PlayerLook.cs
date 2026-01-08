using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] float mouseSense;
    [SerializeField] Transform player, playerArms;
    

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        var mouseDelta = Mouse.current.delta.ReadValue();
        float rotateX = mouseDelta.x * mouseSense; // Input.GetAxis("Mouse X")
        float rotateY = mouseDelta.y * mouseSense; // Input.GetAxis("Mouse Y")

        var yaw = player.rotation.eulerAngles.y;
        var pitch = player.rotation.eulerAngles.x;
        pitch = NormalizePitch(pitch);
        
        yaw += rotateX;
        pitch -= rotateY;

        pitch = Mathf.Clamp(pitch, -90, 90);
        
        player.rotation = Quaternion.Euler(0, yaw, 0);
        playerArms.rotation = Quaternion.Euler(pitch, player.rotation.eulerAngles.y, 0);

    }

    private float NormalizePitch(float pitch)
    {
        if(pitch > 180) pitch -= 360;
        return pitch;
    }
}

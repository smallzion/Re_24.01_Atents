using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Asteroid : TestBase
{
    public Asteroid asteroid;
    public Transform target;
    private void Start()
    {
        target = transform.GetChild(0);
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        asteroid.SetDestination(target.position);
    }
}

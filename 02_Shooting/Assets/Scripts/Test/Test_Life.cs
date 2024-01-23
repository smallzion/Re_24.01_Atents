using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Life : TestBase
{
    public PoolObjectType type;
    Transform spawn;

    private void Start()
    {
        spawn = transform.GetChild(0);
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        Factory.Instance.GetObject(type, spawn.position);
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        base.OnTest3(context);
        GameManager.Instance.Player.Test_Die();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_02_CrossHair : TestBase
{
    Crosshair crossHair;
    public float value = 30.0f;
    private void Start()
    {
        crossHair = FindAnyObjectByType<Crosshair>();
    }
    protected override void OnTestLClick(InputAction.CallbackContext context)
    {
        crossHair.Expend(value);
    }
}

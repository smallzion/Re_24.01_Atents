using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Enemys : TestBase
{
    Transform spawnPoint;
    float randY = 0.0f;
    private void Start()
    {
        
        spawnPoint = transform.GetChild(0);
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        Factory.Instance.GetBonus(spawnPoint.position);
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        //커브 적
        randY = Random.Range(-4, 4);
        Factory.Instance.GetCurve(new Vector3(spawnPoint.position.x, randY, 0));
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        //보스총알
        Factory.Instance.GetBossBullet(spawnPoint.position);
    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
        //보스미사일
        Factory.Instance.GetBossMissile(spawnPoint.position);
    }
    protected override void OnTest5(InputAction.CallbackContext context)
    {
        //보스
    }
}

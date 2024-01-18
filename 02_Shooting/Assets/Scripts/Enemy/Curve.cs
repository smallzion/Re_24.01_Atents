using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Curve : EnemyBase
{
    [Header("커브를 도는 적 데이터")]
    ///<summary>
    ///회전 방향(1이면 반시계, -1이면 시계)
    /// </summary>
    float curveDirection = 1.0f;
    /// <summary>
    ///회전 속도 
    /// </summary>
    public float rotateSpeed = 10.0f;
    protected override void OnInitialize()
    {
        base.OnInitialize();
    }

    protected override void OnMoveUpdate(float deltaTime)
    {
        base.OnMoveUpdate(deltaTime);
        transform.Rotate(deltaTime * rotateSpeed * curveDirection * Vector3.forward);
    }
    /// <summary>
    /// 현재 높이에 따라 회전방향을 갱신하는 함수
    /// </summary>
    public void RefreshRotateDirection()
    {
        if(transform.position.y > 0)
        {
            //좌회전
            curveDirection = -1.0f;
        }
        else
        {
            //우회전
            curveDirection = 1.0f;
        }
    }
}

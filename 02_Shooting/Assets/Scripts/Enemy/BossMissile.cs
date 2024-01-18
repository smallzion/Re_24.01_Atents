using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissile : EnemyBase
{
    [Header("추적 미사일 데이터")]
    ///<summary>
    ///추적대상(플레이어)
    /// </summary>
    Transform target;
    /// <summary>
    /// 유도중인지 표시(true면 유도중, false면 유도 중지)
    /// </summary>
    bool onGuide = true;

    protected override void OnInitialize()
    {
        base.OnInitialize();
        target = GameManager.Instance.Player.transform; // 활성화 될때마다 플레이어 찾기
        onGuide = true;                                 // 유도 켜기
    }

    protected override void OnMoveUpdate(float deltaTime)
    {
        base.OnMoveUpdate(deltaTime);
        if(onGuide) // 유도중이면
        {
            Vector3 dir = target.position - transform.position; // 타겟으로 가는 방향 구하고
//            transform.right = -dir;
            transform.right = -Vector3.Lerp(-transform.right, dir, deltaTime * 0.5f);   // 그쪽 방향으로 회전시키기
            // 시작방향에서 목표로 하는 방향으로 대략 2초에 거쳐서 변경되는 속도
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onGuide && collision.CompareTag("Player"))  // 유도 중일 때 플레이어가 트리거 영역안에 들어왔으면
        {
            onGuide = false;    // 유도 중지
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : RecycleObject
{
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 5.0f;
    public float rotateSpeed = 360.0f;
    Vector3 direction = Vector3.zero;
    
    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(LifeOver(10.0f));
    }

    private void Update()
    {

        transform.Translate(Time.deltaTime * moveSpeed * direction, Space.World);   //direction방향으로이동(월드기준)
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed);
    }

    public void SetDestination(Vector3 detination)
    {
         direction = (detination - transform.position).normalized;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + direction);    //진행방향 표시
    }
}

//실습
//1. 운석은 만들어졌을때 지정된 방향으로 움직인다.
//2. 운석은 계속 회전해야한다.
//3. 운석은 오브젝트풀에서 관리되어야 한다.

//스포너
// 1. 운석 생성용 스포너가 있어야한다.
// 2. 운석을 생성하고 시작점과 도착점을 지정한다.
//스포너에서 생성할 때 스포너의 자식이 되는 문제 있음.
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PowerUp : RecycleObject
{
    //파워업 아이템
    //플레이어가 먹었을 때
    // -1단계에서 먹었을때 : 총알이 2개씩 나간다.
    // - 2단계에서 먹었을 때 : 총알이 3개씩 나간다.
    // - 3단계에서 먹었을 때: 보너스 점수가 1000점 올라간다.
    // 파워업 아이템은 랜덤한 방향으로 움직인다.
    // 일정한 시간 간격으로 이동방향이 변경된다.
    // 높은 확률로 플레이어 반대쪽 방향을 선택한다.
    public float critRate = 0.4f;
    public float moveSpeed = 2.0f;
    public float dirChangeInterval = 1.0f;
    Vector3 dir;
    /// <summary>
    /// 방향전환이 가능한 횟수(최대치)
    /// </summary>
    public int dirChangeCountMax = 5;
    /// <summary>
    /// 남아있는 방향 전환 횟수
    /// </summary>
    int dirChangeCount = 5;
    Animator anim;

    int DirChangCount
    {
        get => dirChangeCount;
        set
        {
            dirChangeCount = value;
            anim.SetInteger("Count", DirChangCount);
            StopAllCoroutines();

            if(dirChangeCount > 0 && gameObject.activeSelf)
            {
                StartCoroutine(DirectionChange());
            }
        }
    }
    Transform playerTransform;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        StopAllCoroutines();                //혹시나 실행되고 있을지도 모르는 모든 코루틴 방지

        playerTransform = GameManager.Instance.Player.transform;
        dir  = Vector3.zero;                //방향 0으로해서 안움직이게
        StartCoroutine(DirectionChange());  //코루틴 실행
        
    }
    /// <summary>
    /// 주기적으로 방향 전환하는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator DirectionChange()
    {
        while (true)
        {
            yield return new WaitForSeconds(dirChangeInterval);
            //약 70%확률로 플레이어 반대방향으로 움직임
            if(DirChangCount > 0)
            {
                if (Random.value < critRate)
                {
                    //플레이어 반대방향
                    Vector2 playerToPowerUp = transform.position - playerTransform.position;
                    dir = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f)) * playerToPowerUp;

                }
                else
                {
                    dir = Random.insideUnitCircle;                          //반지름 1짜리 원 내부의 랜덤한 지점으로 가는 방향 저장
                }
                dir.Normalize();                                        //구한 방향의 크기를 1로 설정
                DirChangCount--;
            }
            
        }
    }
    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * dir);      //항상 direction방향으로 이동
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Border") && 0 < DirChangCount)       //보더랑 부딪히면
        {
            dir = Vector2.Reflect(dir, collision.contacts[0].normal);       //이동 방향 반사시키기
            DirChangCount--;
        }
    }



    /*public float speed = 1.0f;
    public float time = 3.0f;
    public Transform target;
    Vector3 dir;
    public float rand = 0.3f;

    private void Start()
    {
        InvokeRepeating(nameof(ChangeDirection), 0.0f, time); // 처음에 한 번 호출 후 3초마다 반복 호출
    }

    private void Update()
    {
        OnMove();
    }

    private void OnMove()
    {
        transform.Translate(Time.deltaTime * speed * dir);
    }

    private void ChangeDirection()
    {
        if(Random.value > rand)
        {
            if (target != null)
            {
                dir = (transform.position - target.position).normalized;
                Debug.Log("플레이어 반대쪽");
            }
        }
        else
        {
            dir = new Vector3 (Random.value, Random.value, Random.value).normalized;
            Debug.Log("랜?덤");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }*/
}




//실습
//1. 파워업 아이템은 최대 회수만큼만 방향전환을 할 수 있다.(벽에 부딪혀서 방향이 전환된 것도 1회로 취급)
//2. 애니메이터를 이용해서 남아있는 방향 전환 회수에 비례해서 빠르게 깜빡인다.
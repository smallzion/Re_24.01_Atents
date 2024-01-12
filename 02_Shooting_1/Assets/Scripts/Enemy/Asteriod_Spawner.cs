using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;

public class Asteriod_Spawner : EnemySpawner
{
    Transform destinationArea;
    private void Awake()
    {
        destinationArea = transform.GetChild(0);
    }


/*    private void Start()
    {
        StartCoroutine(SpawnCoroutine());   // SpawnCoroutine 코루틴 실행하기
    }

    IEnumerator SpawnCoroutine()
    {
        while (true) // 무한 반복
        {
            yield return new WaitForSeconds(interval);  // interval만큼 기다린 후
            Spawn();                                    // Spawn 실행
        }
    }
*/
    protected override void Spawn()
    {
        Asteroid asteroid = Factory.Instance.GetAsteroid(GetSpawnPosition());
        asteroid.SetDestination(GetDestination());
    }
    Vector3 GetDestination()
    {
        Vector3 pos = destinationArea.position;
        pos.y += Random.Range(MinY, MaxY);  // 현재 위치에서 높이만 (-4 ~ +4) 변경

        return pos;
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        if(destinationArea == null)
        {
            destinationArea = transform.GetChild(0);
        }
    }
}

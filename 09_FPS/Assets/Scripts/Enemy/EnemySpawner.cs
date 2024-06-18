using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemyCount = 50;
    public GameObject enemyPrefab;

    int mazeWidth;
    int mazeHeight;
    Player player;
    Enemy[] enemies;

    private void Awake()
    {
        enemies = new Enemy[enemyCount];
    }

    private void Start()
    {
        // 미로 크기 가져오기
        mazeWidth = GameManager.Instance.MazeWidth;
        mazeHeight = GameManager.Instance.MazeHeight;

        player = GameManager.Instance.Player;

        GameManager.Instance.onGameStart += EnemyAll_Play;
        GameManager.Instance.onGameEnd += (_) => EnemyAll_Stop();
    }

    public void EnemyAll_Spawn()
    {
        // 적 생성
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject obj = Instantiate(enemyPrefab, transform);
            obj.name = $"Enemy_{i}";
            Enemy enemy = obj.GetComponent<Enemy>();
            enemies[i] = enemy;
            enemy.onDie += (target) =>
            {
                GameManager.Instance.IncreaseKillCount();
                StartCoroutine(Respawn(target));
            };
            enemy.Respawn(GetRandomSpawnPosition(true), true);
        }
    }

    /// <summary>
    /// 모든 적을 움직이게 만들기
    /// </summary>
    void EnemyAll_Play()
    {
        foreach (var enemy in enemies)
        {
            enemy.Play();   // Wander상태로 변경
        }
    }

    /// <summary>
    /// 모든 적을 일시정지 시키기(이동, 공격)
    /// </summary>
    void EnemyAll_Stop()
    {
        foreach (var enemy in enemies)
        {
            enemy.Stop();   // 대기상태로 변경
        }
    }

    /// <summary>
    /// 플레이어 주변의 랜덤한 스폰 위치를 구하는 함수
    /// </summary>
    /// <returns>스폰 위치(미로 한 셀의 가운데 지점)</returns>
    Vector3 GetRandomSpawnPosition(bool init = false)
    {
        Vector2Int playerPostion;   // 플레이어의 그리드 위치

        if(init)
        {
            // 플레이어가 정상적으로 있다는 보장이 없는 경우 그냥 미로의 가운데 위치
            playerPostion = new(mazeWidth / 2, mazeHeight / 2); 
        }
        else
        {
            // 일반 플레이 중에는 플레이어의 그리드 위치
            playerPostion = MazeVisualizer.WorldToGrid(player.transform.position);
        }

        int x;
        int y;
        int limit = 100;
        do
        {
            // 플레이어 위치에서  +-5 범위 안이 걸릴 때까지 랜덤돌리기
            int index = Random.Range(0, mazeHeight * mazeWidth);    // 미로 밖은 선택되지 않게 하기
            x = index / mazeWidth;
            y = index % mazeHeight;
            
            limit--;
            if( limit < 1 ) // 최대 100번만 시도하기
                break;

        } while (!(x < playerPostion.x + 5 && x > playerPostion.x - 5 && y < playerPostion.y + 5 && y > playerPostion.y - 5));

        Vector3 world = MazeVisualizer.GridToWorld(x, y);

        return world;
    }

    /// <summary>
    /// 일정 시간 후에 target을 리스폰 시키는 코루틴
    /// </summary>
    /// <param name="target">리스폰 대상</param>
    /// <returns></returns>
    IEnumerator Respawn(Enemy target)
    {
        yield return new WaitForSeconds(3);
        target.Respawn(GetRandomSpawnPosition());
    }

}

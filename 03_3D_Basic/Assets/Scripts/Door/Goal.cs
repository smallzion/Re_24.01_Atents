using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    Player player;
    Transform child;

    private void Awake()
    {
        player = GameManager.Instance.Player;
        child = transform.GetChild(2);
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            child.gameObject.SetActive(true);
            GameClear();
        }
    }

    void GameClear()
    {
        player.transform.gameObject.SetActive(false);
    }
}

    // 플레이어가 트리거 안에 들어오면 클리어
    // 클리어가 되면 폭죽 모두 터트리기

    // 게임 메니저
    // onClear 델리게이트 추가
    //  - 플레이어 수명 정지
    //  - 클리어 화면 띄우기
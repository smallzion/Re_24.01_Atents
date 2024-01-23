using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class LifePanel : MonoBehaviour
{
    Image[] lifeImages;
    Player player;
    public Color disableColor = new Color(1f, 1f, 1f, 0.4f);
    int count;

    private void Start()
    {
        count = transform.childCount;
        lifeImages = new Image[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            lifeImages[i] = child.GetComponent<Image>();

        }

    }

    private void OnEnable()
    {

        player = GameManager.Instance.Player;
        if (player != null)
        {
            player.onLifeChange += OnLifeChange;
        }
    }
    private void OnDisable()
    {
        if (player != null)
        {
            player.onLifeChange -= OnLifeChange;
        }
    }
    private void OnLifeChange(int life)
    {
        Debug.Log(life);


        for(int i = 0; i < life; i++)
        {
            lifeImages[i].color = Color.white;
        }
        for(int i = life; i < lifeImages.Length; i++)
        {
            lifeImages[i].color = disableColor;
        }

        //플레이어의 생명 수치에 따라 표시 변경
        //날아간 생명은 반투명한 회색으로 표시하기

        //이미지 컴포넌트의 색상 변경용 프로퍼티
        // lifeImages[0].color
    }
}

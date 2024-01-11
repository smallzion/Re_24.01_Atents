using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollingSpeed = 2.5f;
    const float BackgroundWidth = 13.6f;
    Transform[] bgSlots;
    float baseLineX = 0.0f;
    //실습
    //배경이 계속 반복되게 만들기

    /*private void Update()
    {
        transform.Translate(Time.deltaTime * scrollingSpeed * Vector2.left);
        if(transform.position.x <= -BackgroundWidth)
        {
            ScrollingBackground();
        }
    }
    private void ScrollingBackground()
    {
        transform.position += new Vector3(BackgroundWidth, 0, 0);

    }*/
    private void Awake()
    {
        bgSlots = new Transform[transform.childCount];
        for(int i = 0; i < bgSlots.Length; i++)
        {
            bgSlots[i] = transform.GetChild(i);
        }
        baseLineX = transform.position.x - BackgroundWidth;
    }
    private void Update()
    {
        for(int i = 0;i < bgSlots.Length; i++)
        {
            bgSlots[i].Translate(Time.deltaTime * scrollingSpeed * Vector2.left);
            if (bgSlots[i].position.x < baseLineX)
            {
                MoveRight(i);
            }
        }
        /*if (bgSlots[1].position.x <= -BackgroundWidth / 2)
        {
            ScrollingBackground();
        }*/
    }

    protected virtual void MoveRight(int index)
    {
        bgSlots[index].Translate(BackgroundWidth * bgSlots.Length * transform.right);
    }

    /*private void ScrollingBackground()
    {
        for (int i = 0; i < bgSlots.Length; i++)
        {
            bgSlots[i].transform.position = new Vector3(bgSlots[i].transform.position.x + BackgroundWidth * 1.5f, 0 ,0);
        }

    }*/
}

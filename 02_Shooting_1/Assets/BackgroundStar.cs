using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStar : Background
{
    Transform[] bgSlot;
    const float BackgroundWidth = 6.8f;
    float baseLine = 0.0f;
    float randCount = 0.0f;

    private void Awake()
    {
        bgSlot = new Transform[transform.childCount];
        for (int i = 0; i < bgSlot.Length; i++)
        {
            bgSlot[i] = transform.GetChild(i);
        }
        baseLine = transform.position.x - BackgroundWidth;
    }

    private void Update()
    {
        for (int i = 0; i < bgSlot.Length; i++)
        {
            bgSlot[i].Translate(Time.deltaTime * scrollingSpeed * Vector2.left);
            if (bgSlot[i].position.x < baseLine)
            {
                MoveRight(i);
            }
        }
    }


    protected override void MoveRight(int index)
    {
        SpriteRenderer spriteRenderer = bgSlot[index].GetComponent<SpriteRenderer>();
        bgSlot[index].Translate(BackgroundWidth * 5 * transform.right);
        randCount = Random.Range(0, 3);
        switch (randCount)
        {
            case 0:
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = false;
                break;
            case 1:
                spriteRenderer.flipX = true;

                spriteRenderer.flipY = true;
                break;
            case 2:
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = true;
                break;
            case 3:
                spriteRenderer.flipX = true;
                spriteRenderer.flipY = false;
                break;
        }
        Debug.Log("x = " + spriteRenderer.flipX);
        Debug.Log("y = " + spriteRenderer.flipY);
    }
}

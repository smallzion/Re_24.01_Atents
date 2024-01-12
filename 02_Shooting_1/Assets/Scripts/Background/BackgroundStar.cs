
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BackgroundStar : Background
{
    SpriteRenderer[] spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        /*bgSlots = new Transform[transform.childCount];
        for (int i = 0; i < bgSlots.Length; i++)
        {

            bgSlots[i] = transform.GetChild(i);
        }
        baseLine = transform.position.x - BackgroundWidth;*/
    }

/*    private void Update()
    {
        for (int i = 0; i < bgSlots.Length; i++)
        {
            bgSlots[i].Translate(Time.deltaTime * scrollingSpeed * Vector2.left);
            if (bgSlots[i].position.x < baseLine)
            {
                MoveRight(i);
            }
        }
    }
*/

    protected override void MoveRight(int index)
    {
        base.MoveRight(index);

        //C#에서 숫자 앞에 0b_를 붙이면 2진수
        //C#에서 숫자 앞에 0x_를 붙이면 16진수;
        int rand = Random.Range(0, 4);
        // 0(0b_00),  1(0b_01), 2(0b_10), 3(Ob_11)

        spriteRenderer[index].flipX = ((rand & 0b_01) != 0);    //rand의 첫번째 비트가 1이면 true 아니면 false 출력
        spriteRenderer[index].flipY = ((rand & 0b_10) != 0);    //rand의 두번째 비트가 1이면 true 아니면 false 출력
    }
    /*{
        
        bgSlot[index].Translate(BackgroundWidth * 5 * transform.right);
        randCount = Random.Range(0, 4);
        switch (randCount)
        {
            case 0:
                spriteRenderer[index].flipX = false;
                spriteRenderer[index].flipY = false;
                break;
            case 1:
                spriteRenderer[index].flipX = true;
                spriteRenderer[index].flipY = true;
                break;
            case 2:
                spriteRenderer[index].flipX = false;
                spriteRenderer[index].flipY = true;
                break;
            case 3:
                spriteRenderer[index].flipX = true;
                spriteRenderer[index].flipY = false;
                break;
        }
        Debug.Log("x = " + spriteRenderer[index].flipX);
        Debug.Log("y = " + spriteRenderer[index].flipY);
    }*/
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VitrualButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    Player player;
    Image img_Jump;
    public Action onJumpInput;
    bool isCoolDown = false;
    private void Awake()
    {
        player = GameManager.Instance.Player;
        Transform child = transform.GetChild(0);
        img_Jump = child.GetComponent<Image>();
        img_Jump.fillAmount = 0;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isCoolDown)
        {
            isCoolDown = true;
            StartCoroutine(CoolTime(player.jumpCoolTime));
            onJumpInput?.Invoke();
        }
        
    }

    IEnumerator CoolTime(float cool)
    {
        img_Jump.fillAmount = 1;
        while (cool > 0.0f)
        {
            cool -= Time.deltaTime;
            img_Jump.fillAmount = cool/ player.jumpCoolTime;
            yield return new WaitForFixedUpdate();
        }
        isCoolDown = false;
    }


    public void OnPointerUp(PointerEventData eventData)
    {

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    RectTransform handleRect;
    RectTransform containerRect;

    float stackRange;

    public Action<Vector2> onMoveInput;
    void Awake()
    {
        containerRect = GetComponent<RectTransform>();
        Transform child = transform.GetChild(0);
        handleRect = child.GetComponent<RectTransform>();
        handleRect = child as RectTransform;
        stackRange = containerRect.rect.width - handleRect.rect.width;
    }
    public void OnDrag(PointerEventData eventData)
    {
        // eventData.position: 마우스 포인터의 현재 스크린 좌표
        Debug.Log("드래그중");
        handleRect.position = eventData.position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            containerRect,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 position);

        position = Vector2.ClampMagnitude(position, stackRange);

        InputUpdate(position);
    }
    

    public void OnPointerUp(PointerEventData eventData)
    {
        //if(eventData.button == PointerEventData.InputButton.Left)
        handleRect.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //OnPointUp과 OnPointDown은 항상 쌍으로 있어야 한다.
    }

    private void InputUpdate(Vector2 inputDelta)
    {
        handleRect.anchoredPosition = inputDelta;
        onMoveInput?.Invoke(inputDelta/stackRange); // (-1,-1)~(1,1)까지  크기를 1로 변환해서 보냄;
    }
}

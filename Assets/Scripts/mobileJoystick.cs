using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mobileJoystick : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    
    private RectTransform joystickTranform;
    [SerializeField] private float dragThreshold = 0.6f;
    [SerializeField] private int dragMovementDistance = 30;
    [SerializeField] private int dragOffsetDistance = 100;
    public event Action<Vector2> OnMove;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickTranform,
            eventData.position,
            null,
            out offset);
        offset = Vector2.ClampMagnitude(offset, dragOffsetDistance) / dragOffsetDistance;
        Debug.Log(offset);
        joystickTranform.anchoredPosition = offset * dragMovementDistance;
        Vector2 inputVector = CalculateMoveMentInput(offset);
        OnMove?.Invoke(inputVector);
    }
    private Vector2 CalculateMoveMentInput(Vector2 offset)
    {
        float x = Mathf.Abs(offset.x) > dragThreshold ? offset.x : 0;
        float y = Mathf.Abs(offset.y) > dragThreshold ? offset.y : 0;
        return new Vector2(x,y);
    }
    // con tro quay ve vi tri ban dau 
    public void OnPointerDown(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickTranform.anchoredPosition = Vector2.zero;
        OnMove.Invoke(Vector2.zero);
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        joystickTranform = (RectTransform)transform;
    }
    
}

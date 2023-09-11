using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropImage : MonoBehaviour, IDragHandler, IDropHandler
{
    public RectTransform rectTransform;

    private Vector2 _startPosition;

    public void OnDrag(PointerEventData eventData)
    {
        //_startPosition = rectTransform;
    }

    public void OnDrop(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = _startPosition + eventData.position;
    }
}

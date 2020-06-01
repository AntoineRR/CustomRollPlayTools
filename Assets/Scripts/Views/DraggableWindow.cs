using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableWindow : MonoBehaviour
{
    [HideInInspector]
    public Vector3 lastPosition;
    [HideInInspector]
    public Vector3 lastMousePosition;

    public void OnClick()
    {
        lastPosition = transform.position;
        lastMousePosition = Input.mousePosition;
    }

    public void OnDrag()
    {
        transform.position = Input.mousePosition - (lastMousePosition - lastPosition);
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Clicker : MonoBehaviour, IPointerClickHandler, IPointerMoveHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(Mouse.current.position.ReadValue() + " " + name);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        Debug.Log("Moved");
    }
}

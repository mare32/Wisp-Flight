using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementJoystick : MonoBehaviour
{
    [SerializeField]
    public Image Joystick;
    public Image JoystickBG;
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;

    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 2f;
        //image1 = GetComponentInChildren<Image>();
        var tempColor = Joystick.color;
        tempColor.a = 0f;
        Joystick.color = tempColor;
        JoystickBG.color = tempColor;
    }

    public void PointerDown()
    {
        //image = GetComponent<Image>();
        var tempColor = Joystick.color;
        tempColor.a = .25f;
        Joystick.color = tempColor;
        JoystickBG.color = tempColor;
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }

        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
        //image = GetComponent<Image>();
        var tempColor = Joystick.color;
        tempColor.a = 0f;
        Joystick.color = tempColor;
        JoystickBG.color = tempColor;
    }

}

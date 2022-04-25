using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickMovement : MonoBehaviour
{
    // Start is called before the first frame update\
    public GameObject joystickBackground;
    public GameObject joystick;
    public Vector2 joystickVec;
    private Vector2 joystickOriginalPos;
    private Vector2 joystickTouchPos;
    private float joystickRadius;
    private Image image1;
    private Image image2;
    void Start()
    {
        joystickOriginalPos = joystickBackground.transform.position;
        joystickRadius = joystickBackground.GetComponent<RectTransform>().sizeDelta.y / 4;
        image1 = joystickBackground.GetComponent<Image>();
        image2 = joystick.GetComponent<Image>();
    }

    // Update is called once per frame
    public void PointerDown()
    {
        if(Input.mousePosition.x >= -joystickRadius * 2 + joystickBackground.transform.position.x && Input.mousePosition.x <= joystickRadius * 2 + joystickBackground.transform.position.x
            && Input.mousePosition.y >= -joystickRadius * 2 + joystickBackground.transform.position.y && Input.mousePosition.y <= joystickRadius * 2 + joystickBackground.transform.position.y)
        {
            joystick.transform.position = Input.mousePosition;
            joystickBackground.transform.position = Input.mousePosition;
            joystickTouchPos = Input.mousePosition;
           
            var tempColor = image1.color;
            tempColor.a = 1;
            image1.color = tempColor;

            tempColor = image2.color;
            tempColor.a = 1;
            image2.color = tempColor;
           

        }

    }
    public void Drag(BaseEventData baseEventData)
    {
        if (Input.mousePosition.x >= -joystickRadius * 2 + joystickBackground.transform.position.x && Input.mousePosition.x <= joystickRadius * 2 + joystickBackground.transform.position.x
           && Input.mousePosition.y >= -joystickRadius * 2 + joystickBackground.transform.position.y && Input.mousePosition.y <= joystickRadius * 2 + joystickBackground.transform.position.y)
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


            //Debug.Log("Joystick Vec: x{0} " + joystickVec.x + ", y{1}" + joystickVec.y);
        }
            
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBackground.transform.position = joystickOriginalPos;

        var tempColor = image1.color;
        tempColor.a = 0.5f;
        image1.color = tempColor;

        tempColor = image2.color;
        tempColor.a = 0.5f;
        image2.color = tempColor;
    }
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MenuItemMouseHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isOver;
    private Color startcolor;


    public void OnPointerEnter(PointerEventData eventData)
    {


        startcolor = GetComponentInChildren<Text>().color;
               
        GetComponentInChildren<Text>().color = new Color32(206,181,57,255);

        isOver = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        GetComponentInChildren<Text>().color = startcolor;
    }


}

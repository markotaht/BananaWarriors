using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuItemMouseHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isOver;
    Color startcolor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var obj in eventData.hovered) Debug.Log(obj);
        //  {
        ///       Debug.Log("on");
        //       startcolor = text1.color;
        //     text1.color = Color.red;
        //  }
        isOver = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
      //  text1.color = startcolor;
    }

}

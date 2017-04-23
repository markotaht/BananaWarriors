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
<<<<<<< HEAD
    private Color startcolor;
=======
    Color startcolor;
>>>>>>> 3983c8370a546a04b03d68038bfbc4aa0bd8d95e

    public void OnPointerEnter(PointerEventData eventData)
    {


        startcolor = GetComponentInChildren<Text>().color;
               
        GetComponentInChildren<Text>().color = Color.yellow;

        isOver = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
<<<<<<< HEAD
        GetComponentInChildren<Text>().color = startcolor;
=======
      //  text1.color = startcolor;
>>>>>>> 3983c8370a546a04b03d68038bfbc4aa0bd8d95e
    }

}

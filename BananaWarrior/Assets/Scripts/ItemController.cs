using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Button sampleButton;                         // sample button prefab
    private List<ContextMenuItem> contextMenuItems;     // list of items in menu

    void Awake()
    {


        contextMenuItems = new List<ContextMenuItem>();
        Action<Image> buildHouse = new Action<Image>(BuildHouse);
        Action<Image> buildSoldier = new Action<Image>(BuildSoldier);
        Action<Image> drop = new Action<Image>(DropAction);

        contextMenuItems.Add(new ContextMenuItem("Build house (2 GB)", sampleButton, buildHouse));
        contextMenuItems.Add(new ContextMenuItem("Build soldier (2 YB)", sampleButton, buildSoldier));
        contextMenuItems.Add(new ContextMenuItem("Drop", sampleButton, drop));
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            ContextMenu.Instance.CreateContextMenu(contextMenuItems, new Vector2(pos.x, pos.y));
        }

    }

    void BuildHouse(Image contextPanel)
    {
        Debug.Log("Maja");
        Destroy(contextPanel.gameObject);
    }

    void BuildSoldier(Image contextPanel)
    {
        Debug.Log("Sõdur");
        Destroy(contextPanel.gameObject);
    }

    void DropAction(Image contextPanel)
    {
        Debug.Log("Dropped");
        Destroy(contextPanel.gameObject);
    }
}
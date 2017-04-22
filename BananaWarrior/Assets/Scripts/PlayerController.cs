using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MoveController))]
[RequireComponent (typeof(InventoryController))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    public MoveController movementController
    {
        get { return movementController; }
        set { movementController = value; }
    }

    [SerializeField]
    public InventoryController inventoryController
    {
        get { return inventoryController; }
        set { inventoryController = value; }
    }

	// Use this for initialization
	void Start () {
        movementController = GetComponent<MoveController>();
        inventoryController = GetComponent<InventoryController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

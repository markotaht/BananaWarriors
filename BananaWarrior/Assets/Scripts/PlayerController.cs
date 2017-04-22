using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MoveController))]
[RequireComponent (typeof(InventoryController))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private MoveController mc;
    private float life = 90.0f;

    public float Life
    {
        get { return life; }
        set { life = value; }
    }

    public MoveController movementController
    {
        get { return mc; }
        set { mc = value; }
    }

    [SerializeField]
    private InventoryController ic;
    public InventoryController inventoryController
    {
        get { return ic; }
        set { ic = value; }
    }

	// Use this for initialization
	void Start () {
        mc = GetComponent<MoveController>();
        ic = GetComponent<InventoryController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //returns if the unit was killed
    public bool onHit()
    {
        life -= 5;
        if (life <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        //End of game
    }

}

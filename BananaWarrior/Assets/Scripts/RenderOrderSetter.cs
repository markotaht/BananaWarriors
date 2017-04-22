using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOrderSetter : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = (int)((transform.position.y- spriteRenderer.bounds.size.y/2) * -10);
    }
}

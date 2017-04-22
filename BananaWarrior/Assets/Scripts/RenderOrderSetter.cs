using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOrderSetter : MonoBehaviour {
    private SpriteRenderer renderer;
    
    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sortingOrder = (int)((transform.position.y-renderer.bounds.size.y/2) * -10);
    }
}

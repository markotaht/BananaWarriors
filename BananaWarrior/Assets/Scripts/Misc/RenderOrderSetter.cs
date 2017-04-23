using UnityEngine;
using UnityEngine.Rendering;

public class RenderOrderSetter : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private SortingGroup sortingGroup;

    [SerializeField]
    private int offset = 0;
    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        sortingGroup = GetComponent<SortingGroup>();
        sortingGroup.sortingOrder = (int)((transform.position.y) * -10) + offset;
    }
}

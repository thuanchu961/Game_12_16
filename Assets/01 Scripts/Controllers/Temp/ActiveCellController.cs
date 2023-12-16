using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCellController : MonoBehaviour, ISetActiveCell
{
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetActiveCell()
    {
        spriteRenderer.enabled = true;
    }
}

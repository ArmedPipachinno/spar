using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProperties : MonoBehaviour
{
    private SpriteRenderer currentRenderer;
    private Color currentColor;

    private void Start()
    {
        currentRenderer = GetComponent<SpriteRenderer>();
        currentColor = currentRenderer.color;
    }

    private void OnMouseOver()
    {
        currentRenderer.color = new Color(currentColor.r+0.1f, currentColor.g+0.1f, currentColor.b+0.1f);
    }

    private void OnMouseExit()
    {
        currentRenderer.color = currentColor;
    }


}

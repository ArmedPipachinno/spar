using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProperties : MonoBehaviour
{
    private SpriteRenderer currentRenderer;
    private Color currentColor;
    private Vector2 nowPos;

    private void Start()
    {
        nowPos = GetComponent<Transform>().position;
        currentRenderer = GetComponent<SpriteRenderer>();
        currentColor = currentRenderer.color;
    }

    // Mouse Event will work when Object has Collision
    private void OnMouseOver()
    {
        // Change Color when Mouse Hover if there is no tower on that grid
        if (GameManage.currentGameUI == GameManage.GameUI.playing && !MapGenerator.mapCheck[(int)nowPos.x,(int)-nowPos.y])
        {
            currentRenderer.color = new Color(currentColor.r + 0.1f, currentColor.g + 0.1f, currentColor.b + 0.1f);
        }
    }

    private void OnMouseExit()
    {
        currentRenderer.color = currentColor;
    }

    private void OnMouseDown()
    {
        // Mouse Click -> Show createTowerUI if there is no tower on that grid
        if (GameManage.currentGameUI == GameManage.GameUI.playing && !MapGenerator.mapCheck[(int)nowPos.x, (int)-nowPos.y])
        {
            Vector3 nowPos = GetComponent<Transform>().position;
            // Track the position that have been clicked
            GameManage.clickPos = nowPos;
            GameManage.currentGameUI = GameManage.GameUI.createTowerUI;
        }
    }

}

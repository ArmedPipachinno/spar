using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Vector2[] path;
    [SerializeField] private float speed;
    private int now = 0;

    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("MapManager");
    }

    private void Update()
    {
        if(now<path.Length-1)
        {
            Walk();
        }
        else
        {
            // If Enemy was at base decrease Life and destroy this Game object
            gameManager.GetComponent<GameManage>().AddHealth(-1);
            Destroy(this.gameObject);
        }
    }

    private void Walk()
    {
        // Make Enemy walk from grid to grid
        Vector2 dif = path[now + 1] - path[now];
        if((int)dif.x > 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= path[now + 1].x)
            {
                now++;
            }
        }
        else if((int)dif.x < 0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= path[now + 1].x)
            {
                now++;
            }
        }
        else if ((int)dif.y > 0)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (transform.position.y >= path[now + 1].y)
            {
                now++;
            }
        }
        else if ((int)dif.y < 0)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (transform.position.y <= path[now + 1].y)
            {
                now++;
            }
        }

    }

    // Function for Set path (note: SetPath from EnemyPath.cs)
    public void SetPath(Vector2[] pathRef)
    {
        path = pathRef;
    }
}

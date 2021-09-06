using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Vector2[] path;
    [SerializeField] private float speed;
    [SerializeField] private int health;
    private int now = 0;

    private void Start()
    {

    }

    private void Update()
    {
        if(GameManage.currentGameStatus != GameManage.GameStatus.PAUSE &&
            GameManage.currentGameStatus != GameManage.GameStatus.GAMEOVER)
        {
            // Walk until there have no path
            if(now<path.Length-1)
            {
                Walk();
            }
            CheckHealth();
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

    private void CheckHealth()
    {
        if(health <= 0 )
        {
            Destroy(gameObject);
        }
    }

    public void AddHealth(int _health)
    {
        health += _health;
    }

    // Function for Set path (note: SetPath from EnemyPath.cs)
    public void SetPath(Vector2[] pathRef)
    {
        path = pathRef;
    }

}

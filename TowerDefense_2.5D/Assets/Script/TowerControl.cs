using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float range;
    [SerializeField] private float shootDelay;
    private float shootTimeCounter = 0.0f;
    private bool foundEnemy = false;

    private LinkedList<GameObject> enemyList;

    private void Start()
    {
        enemyList = new LinkedList<GameObject>();
    }

    private void Update()
    {
        if(GameManage.currentGameStatus != GameManage.GameStatus.PAUSE && 
            GameManage.currentGameStatus != GameManage.GameStatus.GAMEOVER)
        {
            CheckEnemy();
            CoolDown();
        }
    }
   
    // Cool down for Shooting bullet
    private void CoolDown()
    {
        if (shootTimeCounter >= shootDelay)
        {
            if(foundEnemy)
            {
               Shoot();
               shootTimeCounter = 0;
            }
        }
        else
        {
            shootTimeCounter += Time.deltaTime;
        }
    }

    // Shoot bullet to Enemy
    private void Shoot()
    {
        GameObject bulletGo = Instantiate(bulletPrefab, transform.position, transform.rotation);
        BulletScript bullet = bulletGo.GetComponent<BulletScript>();
        if (bullet != null)
        {
            bullet.Seek(enemyList.First.Value);
        }
    }

    private void CheckEnemy()
    {
        CheckEnemyDis();
        Collider2D[] enemyRef = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (var enemy in enemyRef)
        {
            if (enemy.gameObject.CompareTag("Enemy"))
            {
                foundEnemy = true;
                if (enemyList.Count == 0 )
                {
                    enemyList.AddLast(enemy.gameObject);
                }
            }
        }
        foundEnemy = (enemyList.Count > 0) ? true : false;
    }


    // If Enemy far from range -> delete from enemyList
    // If Enemy die -> delete from enemyList
    private void CheckEnemyDis()
    {
        if(enemyList.Count == 0)
        {
            return;
        }
        else if(enemyList.First.Value == null)
        {
            enemyList.RemoveFirst();
        }
        else if(Vector2.Distance(enemyList.First.Value.transform.position, transform.position) > range)
        {
            enemyList.RemoveFirst();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}

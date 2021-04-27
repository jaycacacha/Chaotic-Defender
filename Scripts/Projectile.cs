using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    private Transform enemy;
    private Vector2 target;
    public GameObject BulletParticle;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        target = new Vector2(enemy.position.x, enemy.position.y);
    }
    // Update is called once per frame
    void Update()
    {

        if (EnemyScript.isVisible == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyProjectile();
                CallProjectileExplosion();
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Score.ScoreValue += 100;
            Score.KillsPerRound += 1;
            DestroyProjectile();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Boss"))
        {
            DestroyProjectile();
        }


    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    void CallProjectileExplosion()
    {
        Instantiate(BulletParticle, transform.position, Quaternion.identity);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    SpriteRenderer spriteRenderer;
    public float speedReduced;
    private Transform target;
    public GameObject EnemyParticle;
    private int RandomSpawnItem;
    public GameObject HeartPrefab;
    public GameObject CoinPrefab;
    public static bool isVisible;
    void Start()
    {
        speed = Random.Range(1.3f, 3.5f);
        speedReduced = 0.5f;

        spriteRenderer = GetComponent<SpriteRenderer>();


        if (speed >= 1.8 && speed <= 2.5)
        {
            spriteRenderer.color = Color.green;
        }
        else if (speed >= 2.6)
        {
            spriteRenderer.color = Color.yellow;
        }
    }

    void Update()
    {
        if (PlayerControl.isDead == false)
        {
            if (PlayerControl.isInvincible == false)
            {
                //move towards the player
                transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, speedReduced * Time.deltaTime);
            }
        }

        //move away to the player
        //transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, -speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            CallEnemyExplosion();
            RandomSpawnItem = Random.Range(0, 100);
            if (RandomSpawnItem >= 96)
            {
                SpawnHeart();
            }
            else if (RandomSpawnItem <= 20)
            {
                SpawnCoin();
            }
        }

    }
    void CallEnemyExplosion()
    {
        Instantiate(EnemyParticle, transform.position, Quaternion.identity);
    }
    public void OnBecameVisible()
    {
        isVisible = true;
    }

    void SpawnHeart()
    {
        var HeartDrop = Instantiate(HeartPrefab, transform.position, Quaternion.identity);
        Destroy(HeartDrop, 5);
    }
    void SpawnCoin()
    {
        var CoinDrop = Instantiate(CoinPrefab, transform.position, Quaternion.identity);
        Destroy(CoinDrop, 5);
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameOverScript GameOverUI;
    public static float moveSpeed;
    public GameObject projectile;
    private float timeBetweenShots;
    private float StartTimeBetweenShots;
    public GameObject PlayerExplosion;
    private Vector2 camPosition;
    public static int health;

    public static int maxHealth;
    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    Renderer PlayerRender;
    Color PlayerColor;
    public static bool isInvincible;
    public static bool isDead;
    private float DeathDelay;
    public AudioSource Explosion, PickupCoin, PickupHeart, PlayerDamage, Shoot, SelectOption, GameOver;
    public Joystick PlayerJoystick;
    public static float positiveX;
    public static float negativeX;
    public static float positiveY;
    public static float negativeY;
    public static bool playerCanShoot;

    GameObject[] Enemies;
    void Start()
    {
        moveSpeed = 12f;
        positiveX = 16f;
        negativeX = -16f;
        positiveY = 7.5f;
        negativeY = -7.5f;

        PlayerRender = GetComponent<Renderer>();
        PlayerColor = PlayerRender.material.color;
        playerCanShoot = true;
        isInvincible = false;
        isDead = false;
        DeathDelay = 2f;


        Explosion.volume = PlayerPrefs.GetFloat("SFXVolume");
        PickupCoin.volume = PlayerPrefs.GetFloat("SFXVolume");
        PickupHeart.volume = PlayerPrefs.GetFloat("SFXVolume");
        PlayerDamage.volume = PlayerPrefs.GetFloat("SFXVolume");
        Shoot.volume = PlayerPrefs.GetFloat("SFXVolume");
        SelectOption.volume = PlayerPrefs.GetFloat("SFXVolume");
        GameOver.volume = PlayerPrefs.GetFloat("SFXVolume");
        if (PlayerPrefs.GetInt("BulletFirstUpgradeBool") == 0)
        {
            StartTimeBetweenShots = 1.1f;
        }
        if (PlayerPrefs.GetInt("BulletFirstUpgradeBool") == 1)
        {
            StartTimeBetweenShots = PlayerPrefs.GetFloat("TimeBetweenShotDefault");
        }

        timeBetweenShots = StartTimeBetweenShots;

        if (PlayerPrefs.GetInt("DefaultMaxHP") <= 3)
        {
            maxHealth = 3;
        }
        else
        {
            maxHealth = PlayerPrefs.GetInt("DefaultMaxHP");
        }

        health = maxHealth;

    }
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, negativeX, positiveX), Mathf.Clamp(transform.position.y, negativeY, positiveY), transform.position.z);
        if (isDead == false)
        {
            //    Vector2 TouchPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(PlayerJoystick.Horizontal * moveSpeed * Time.deltaTime, PlayerJoystick.Vertical * moveSpeed * Time.deltaTime, 0);
        }
        SetupHP();
        if (playerCanShoot == true && EnemyScript.isVisible == true)
        {
            if (timeBetweenShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                Shoot.PlayOneShot(Shoot.clip);
                timeBetweenShots = StartTimeBetweenShots;
            }
            else
            {

                timeBetweenShots -= Time.deltaTime;

            }
        }
    }
    void SetupHP()
    {

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    void LoseHealth()
    {
        if (health >= 1)
        {
            health--;
        }
        if (health == 0)
        {
            Explosion.PlayOneShot(Explosion.clip);
            isDead = true;
            playerCanShoot = false;
            Score.DeathRound += 1;
            StartCoroutine(PlayerGameOver());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (isInvincible == false)
            {
                PlayerDamage.PlayOneShot(PlayerDamage.clip);
                LoseHealth();
                StartCoroutine(SetInvulnerability());
            }

        }
        if (other.CompareTag("Heart"))
        {
            if (health < hearts.Length)
            {
                PickupHeart.PlayOneShot(PickupHeart.clip);

                health++;
                hearts[health - 1].sprite = FullHeart;
                Destroy(other.gameObject);
            }
        }
        if (other.CompareTag("Coin"))
        {
            if (PlayerPrefs.GetInt("CoinFirstUpgradeBool") == 0)
            {
                Score.CoinStorage += 1 * 1;
            }
            if (PlayerPrefs.GetInt("CoinFirstUpgradeBool") == 1)
            {
                Score.CoinStorage += 1 * (PlayerPrefs.GetInt("CoinMultiplier"));
            }
            PickupCoin.PlayOneShot(PickupCoin.clip);
            Destroy(other.gameObject);
        }
    }
    IEnumerator SetInvulnerability()
    {
        if (health > 1)
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
            PlayerColor.a = 0.5f;
            PlayerRender.material.color = PlayerColor;
            isInvincible = true;

            yield return new WaitForSeconds(2.5f);
            Physics2D.IgnoreLayerCollision(6, 7, false);
            PlayerColor.a = 1f;
            PlayerRender.material.color = PlayerColor;
            isInvincible = false;
        }
    }
    IEnumerator PlayerGameOver()
    {

        GameOver.PlayOneShot(GameOver.clip);
        Instantiate(PlayerExplosion, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(DeathDelay);
        CallGameOverUI();
        Time.timeScale = 0;

    }
    void CallGameOverUI()
    {
        GameOverUI.Setup();
    }
}


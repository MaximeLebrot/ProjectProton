using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField]
    public static GameController instance;

    private static float health = 6;
    private static int maxHealth = 6;
    private static float moveSpeed = 5f;
    private static float fireRate = 0.5f;
    private static float bulletSize = 0.5f;
    private static bool playerImmune;

    public static float Health { get => health; set => health = value; }
    public static int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public static float FireRate { get => fireRate; set => fireRate = value; }
    public static float BulletSize { get => bulletSize; set => bulletSize = value; }
    public static bool ImmuneState { get => playerImmune; set => playerImmune = value; }

    public Text healthText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        healthText.text = "Health: " + health;
    }

    public static void DamagePlayer(int damage)
    {
        if (!playerImmune)
        {
            health -= damage;
        }
        
        if (health <= 0)
        {
            KillPlayer();
        }
    }

    public static void Immune(bool immune)
    {
        playerImmune = immune;
    }

    public static void HealPlayer(float healAmount)
    {
        health = Mathf.Min(maxHealth, health, healAmount);
    }

    public static void MoveSpeedChange(float speed)
    {
        moveSpeed += speed;
    }

    public static void FireRateChange(float rate)
    {
        fireRate -= rate;
    }

    public static void BulletSizeChange(float size)
    {
        bulletSize += size;
    }
    
    private static void KillPlayer()
    {
     SceneManager.LoadScene(0);
     GameController.Health = 6;
     DungeonCrawlerController.positionsVisited.Clear();  
    }
}


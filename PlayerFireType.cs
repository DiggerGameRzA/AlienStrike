using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireType : MonoBehaviour
{
    public static int bulletType = 1;
    public static bool shoot = false;

    public GameObject bullet,bullet2; //Prefab of bullet for instantiate
    public Transform[] bulletPos; //Posision for shooting bullets

    public static float bulletDamage; //Damage of bullet

    public float firePerSecond; //Rate of fire
    public float bulletSpeed; //Velocity of bullet
    public float fireDelay;

    #region Bullet Settings

    //Normal Bullet Tier 1

    [Header("Normal Bullet Tier 1 Settings")]
    // Damage
    public float DamageType01;
    // Fire per second
    public float FireRateType01;
    // Velocity
    public float bulletSpeedType01;

    // Normal Bullet Tier 2

    [Header("Normal Bullet Tier 2 Settings")]
    // Damage
    public float DamageType02;
    // Fire per second
    public float FireRateType02;
    // Velocity
    public float bulletSpeedType02;

    // Burst Bullet Tier 1

    [Header("Burst Bullet Tier 1 Settings")]
    // Damage
    public float DamageType03;
    // Fire per second
    public float FireRateType03;
    // Velocity
    public float bulletSpeedType03;

    // Burst Bullet Tier 2

    [Header("Burst Bullet Tier 2 Settings")]
    // Damage
    public float DamageType04;
    // Fire per second
    public float FireRateType04;
    // Velocity
    public float bulletSpeedType04;

    #endregion
    void Awake()
    {
        bulletSpeed = bulletSpeedType01; //Set velocity of bullet

        fireDelay = 0.1f;
    }
    void Start()
    {
        //InvokeRepeating("FireBullet", 10, fireDelay); //Fire bullet repeatedly
        StartCoroutine(FireBullet());

        bulletSpeed = bulletSpeedType01; //Set velocity of bullet

        Invoke("startFire", 0.1f);
    }

    void Update()
    {
        bulletStatus();
    }
    IEnumerator FireBullet()
    {
        do
        {
            if (bulletType == 1)
            {
                Bullet01();
            }
            else if (bulletType == 2)
            {
                Bullet02();
            }
            else if (bulletType == 3)
            {
                Bullet03();
            }
            else if (bulletType == 4)
            {
                Bullet04();
            }
            yield return new WaitForSeconds(fireDelay);
        }
        while (shoot);


    }

    void bulletStatus()
    {
        fireDelay = 1 / firePerSecond;
        if (Player_Ctrl.Health <= 0)
        {
            shoot = false;
        }
        else if (bulletType == 1)
        {
            bulletDamage = DamageType01; //Set damage of bullet
            firePerSecond = FireRateType01; //Set fire rate of bullet
            bulletSpeed = bulletSpeedType01; //Set velocity of bullet
        }
        else if (bulletType == 2)
        {
            bulletDamage = DamageType02; //Set damage of bullet
            firePerSecond = FireRateType02; //Set fire rate of bullet
            bulletSpeed = bulletSpeedType02; //Set velocity of bullet
        }
        else if (bulletType == 3)
        {
            bulletDamage = DamageType03; //Set damage of bullet
            firePerSecond = FireRateType03; //Set fire rate of bullet
            bulletSpeed = bulletSpeedType03; //Set velocity of bullet
        }
        else if (bulletType == 4)
        {
            bulletDamage = DamageType04; //Set damage of bullet
            firePerSecond = FireRateType04; //Set fire rate of bullet
            bulletSpeed = bulletSpeedType04; //Set velocity of bullet
        }
    }
    
    void Bullet01() //Shoot Tier 1 normal bullet
    {
        GameObject Bullet1 = Instantiate(bullet, bulletPos[2].position, bullet.transform.rotation);
        Bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
    }
    void Bullet02() //Shoot Tier 2 normal bullet
    {
        GameObject Bullet1 = Instantiate(bullet, bulletPos[0].position, bullet.transform.rotation);
        GameObject Bullet2 = Instantiate(bullet, bulletPos[1].position, bullet.transform.rotation);
        Bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
        Bullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
    }
    void Bullet03() //Shoot Tier 1 burst bullet
    {
        GameObject Bullet1 = Instantiate(bullet2, bulletPos[2].position, bullet2.transform.rotation);
        GameObject Bullet2 = Instantiate(bullet2, bulletPos[0].position, bullet2.transform.rotation);
        GameObject Bullet3 = Instantiate(bullet2, bulletPos[1].position, bullet2.transform.rotation);
        Bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
        Bullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed * 0.4f, bulletSpeed * 0.9f);
        Bullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * 0.4f, bulletSpeed * 0.9f);
    }
    void Bullet04() //Shoot Tier 2 burst bullet
    {
        GameObject Bullet1 = Instantiate(bullet2, bulletPos[2].position, bullet2.transform.rotation);
        GameObject Bullet2 = Instantiate(bullet2, bulletPos[0].position, bullet2.transform.rotation);
        GameObject Bullet3 = Instantiate(bullet2, bulletPos[1].position, bullet2.transform.rotation);
        GameObject Bullet4 = Instantiate(bullet2, bulletPos[3].position, bullet2.transform.rotation);
        GameObject Bullet5 = Instantiate(bullet2, bulletPos[4].position, bullet2.transform.rotation);
        Bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
        Bullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed * 0.4f, bulletSpeed * 0.9f);
        Bullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * 0.4f, bulletSpeed * 0.9f);
        Bullet4.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed * 0.2f, bulletSpeed * 0.95f);
        Bullet5.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * 0.2f, bulletSpeed * 0.95f);
    }
    void startFire()
    {
        shoot = true;
    }
}
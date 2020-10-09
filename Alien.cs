using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int AlienType;
    WaveSystem WS = new WaveSystem();

    float Health;
    public float SpeedMovement = 10;
    Vector2 endPosition;
    Rigidbody2D rb;

    public GameObject bullet;
    public Transform bulletPos;

    [SerializeField] float bulletSpeed; //Velocity of bullet
    [SerializeField] float firePerSecond; //Rate of fire
    float fireDeley;

    SpriteRenderer sr;
    bool hit = false;
    Material matWhite;
    Material matDefualt;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefualt = sr.material;

        WS.EnemyHasSpawned();
    }
    void Start()
    {
        endPosition = transform.position + new Vector3(0, -7);

        Health = 50f;
        if(AlienType == 1)
        {
            fireDeley = 1 / firePerSecond;
            InvokeRepeating("Bullet01", 2f, fireDeley);
        }
        
    }
    void Update()
    {
        if (Health <= 0)
        {
            WS.EnemyDie();
            Destroy(this.gameObject);
        }

        if (hit)
        {
            sr.material = matWhite;
            Invoke("resetWhite", 0.01f);
        }
        else
        {
            sr.material = matDefualt;
        }

    }
    void FixedUpdate()
    {
        if (rb.position != endPosition)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb.position, endPosition, SpeedMovement * Time.deltaTime);
            rb.MovePosition(newPosition);
        }
    }
    private void OnTriggerEnter2D(Collider2D col1)
    {
        if (col1.gameObject.tag == "Bullet")
        {
            Health -= PlayerFireType.bulletDamage;
            hit = true;
        }
    }

    void Bullet01() //Shoot Tier 1 normal bullet
    {
        GameObject Bullet1 = Instantiate(bullet, bulletPos.position, bullet.transform.rotation);
        Bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
    }
    void resetWhite()
    {
        hit = false;
    }
}

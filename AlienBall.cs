using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBall : MonoBehaviour
{
    WaveSystem WS = new WaveSystem();

    public float SpeedMovement;
    float Health;
    Transform playerPosition;
    Rigidbody2D rb;

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
    private void Start()
    {
        Health = 70f;

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (Health <= 0)
        {
            WS.EnemyDie();
            Destroy(this.gameObject);
        }

        Vector3 direction = playerPosition.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        rb.rotation = angle;

        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, SpeedMovement * Time.deltaTime);
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
    private void OnTriggerEnter2D(Collider2D col1)
    {
        if (col1.gameObject.tag == "Bullet")
        {
            hit = true;
            Health -= PlayerFireType.bulletDamage;
        }
    }
    void resetWhite()
    {
        hit = false;
    }
}

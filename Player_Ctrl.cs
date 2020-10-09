using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ctrl : MonoBehaviour
{
    public static int Health = 3; //Health of player

    bool invincible = false;
    Material matInvis;
    Material matDefualt;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        Health = 3;

        matInvis = Resources.Load("Invisible", typeof(Material)) as Material;
        matDefualt = sr.material;

        Cursor.visible = false; //Make cursor invisible
    }

    private void OnTriggerEnter2D(Collider2D col1)
    {
        if (!invincible)
        {
            if ((col1.CompareTag("Enemy") || col1.CompareTag("BulletEnemy")) && (Health > 1))
            {
                Health--;
                invincible = true; //Player can not take any damage
                Invoke("resetInvincible", 3); //Make player not invincible in 3 seconds
            }
            else if ((col1.CompareTag("Enemy") || col1.CompareTag("BulletEnemy")) && (Health == 1))
            {
                Health--;
            }
        }
    }

    void Update()
    {
        if (Health <= 0)
        {
            //this.gameObject.SetActive(false); //Deactivate a player
            sr.material = matInvis;
            Cursor.visible = true;
            PlayerFireType.shoot = false;
        }
        else if (WaveSystem.GameEndedBool)
        {
            transform.position = transform.position;
            PlayerFireType.shoot = false;
            Cursor.visible = true;
        }
        else if (Health > 0)
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouse; //Make position of player is same as position of mouse
        }
        if (invincible)
        {
            sr.material = matInvis;
            Invoke("resetSprite", .5f);
        }
    }
    
    void resetInvincible()
    {
        invincible = false;
    }
    void resetSprite()
    {
        sr.material = matDefualt;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int TypeOfBullet;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerFireType.bulletType = TypeOfBullet;
            Destroy(this.gameObject);
        }
    }
}

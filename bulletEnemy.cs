using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour
{
    float lifeTime = 2f;
    void Update()
    {
        lifeTime -= 1 * Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col1)
    {
        if (col1.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}

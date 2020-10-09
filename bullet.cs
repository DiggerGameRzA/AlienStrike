using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y >= 5.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col1)
    {
        if(col1.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}

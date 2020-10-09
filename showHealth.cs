using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHealth : MonoBehaviour
{
    public Text Health,GameOver;
    public GameObject Ended;
    void Update()
    {
        Health.GetComponent<Text>().text = Player_Ctrl.Health.ToString();
        if (Player_Ctrl.Health <= 0)
        {
            GameOver.gameObject.SetActive(true);
            Ended.gameObject.SetActive(true);
        }
    }
}

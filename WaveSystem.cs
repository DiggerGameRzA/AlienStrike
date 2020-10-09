using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    public float CountdownTime = 5f;

    public int WaveIndex = 3;
    int CurrentWave = 0;
    public float WaveDeley = 2f;
    bool AllEnemyDie = false;

    public Text timeText;
    public Text StageIsClear;
    public Text waveText;
    public Text GameEndText;
    public Text GameOver;
    public GameObject Ended;

    public GameObject[] Enemy;
    [SerializeField] public static int EnemyLeft = 0;

    public GameObject[] SpawnPoint = new GameObject[9];
    bool StartSpawn = false;
    [SerializeField] public static bool GameEndedBool = false;

    void Awake()
    {
        GameOver.gameObject.SetActive(false);
        Ended.gameObject.SetActive(false);
        GameEndedBool = false;
    }

    void Update()
    {
        if(CountdownTime <= 0 && !StartSpawn) //When countdowntime is 0 start spawn wave
        {
            timeText.gameObject.SetActive(false);
            if(CurrentWave < WaveIndex)
            {
                CurrentWave++;
            }
            DisplayWave(CurrentWave, WaveIndex);
            StartWave(CurrentWave);
            StartSpawn = true;
        }
        else
        {
            DisplayTime(CountdownTime);
            CountdownTime -= Time.deltaTime;
        }

        if(CurrentWave < WaveIndex)
        {
            if (EnemyLeft <= 0 && StartSpawn && !AllEnemyDie)
            {
                print("No enemy left");
                AllEnemyDie = true;
            }
            else
            {
                print("There are enemies here!!");
                AllEnemyDie = false;
            }
        }
        if(CurrentWave == WaveIndex && EnemyLeft <=0 && StartSpawn)
        {
            GameEnded();
        }
        if (AllEnemyDie)
        {
            StartSpawn = false;
            CountdownTime = WaveDeley;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float Seconds = Mathf.FloorToInt(timeToDisplay);
        if(Seconds != 0)
        {
            timeText.text = Seconds.ToString();
        }
    }
    void DisplayWave(int CrW,int Wid)
    {
        waveText.text = "Wave " + CrW.ToString() + "/" + Wid.ToString();
    }
    void StartWave(int currentWave)
    {
        //Instantiate enemies to spawn points
        if (currentWave == 1)
        {
            foreach (GameObject i in SpawnPoint)
            {
                Instantiate(Enemy[0], i.transform.position, Enemy[0].transform.rotation);
            }
        }
        else if(currentWave == 2)
        {
            Instantiate(Enemy[1], SpawnPoint[0].transform.position, Enemy[1].transform.rotation);
            Instantiate(Enemy[1], SpawnPoint[6].transform.position, Enemy[1].transform.rotation);
            Instantiate(Enemy[1], SpawnPoint[7].transform.position, Enemy[1].transform.rotation);
            Instantiate(Enemy[1], SpawnPoint[4].transform.position, Enemy[1].transform.rotation);
        }
        else if(currentWave == 3)
        {
            Instantiate(Enemy[2], SpawnPoint[5].transform.position, Enemy[2].transform.rotation);
            Instantiate(Enemy[2], SpawnPoint[1].transform.position, Enemy[2].transform.rotation);
            Instantiate(Enemy[2], SpawnPoint[8].transform.position, Enemy[2].transform.rotation);
            Instantiate(Enemy[2], SpawnPoint[3].transform.position, Enemy[2].transform.rotation);

            Instantiate(Enemy[1], SpawnPoint[6].transform.position, Enemy[1].transform.rotation);
            Instantiate(Enemy[1], SpawnPoint[7].transform.position, Enemy[1].transform.rotation);

            Instantiate(Enemy[0], SpawnPoint[0].transform.position, Enemy[0].transform.rotation);
            Instantiate(Enemy[0], SpawnPoint[2].transform.position, Enemy[0].transform.rotation);
            Instantiate(Enemy[0], SpawnPoint[4].transform.position, Enemy[0].transform.rotation);
        }

    }
    public void EnemyDie()
    {
        EnemyLeft--;
    }
    public void EnemyHasSpawned()
    {
        EnemyLeft++;
    }
    void GameEnded()
    {
        PlayerFireType.shoot = false;
        Ended.gameObject.SetActive(true);
        GameEndText.text = "Stage Clear!";
        print("Game is ended");
        GameEndedBool = true;
    }
}

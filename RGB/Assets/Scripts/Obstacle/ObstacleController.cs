using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private float SpawnDelay = 1;
    [SerializeField]
    private bool spawning = false;
    public GameObject[] Gates;
    public GameObject[] Obstacles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!spawning && GameManager.Instance.gameStarted)
        {
            //Debug.Log("update, start spawning");
            InvokeRepeating("StartSpawning", 0, SpawnDelay);
        }

        if (!GameManager.Instance.gameStarted && spawning)
        {
            //Debug.Log("Stop Spawning");
            CancelInvoke("StartSpawning");
            spawning = false;
        }  
    }

    private void StartSpawning()
    {
        spawning = true;
        SpawnObstacleOrGate();
    }

    private void SpawnObstacleOrGate()
    {
        int i = Random.Range(0, 10);
        if (i <= 7)
        {
            SpawnGate();
        }
        else
        {
            SpawnObstacle();
        }
    }

    private void SpawnGate()
    {
        int gateInt = Random.Range(0,Gates.Length);
        if (gateInt == 3) gateInt--;
        Instantiate(Gates[gateInt], Gates[gateInt].transform.position, Gates[gateInt].transform.rotation);
    }

    private void SpawnObstacle()
    {
        int obstacleInt = Random.Range(0, Obstacles.Length);
        if (obstacleInt == 3) obstacleInt--;
        Instantiate(Obstacles[obstacleInt], Obstacles[obstacleInt].transform.position, Obstacles[obstacleInt].transform.rotation);
    }
}

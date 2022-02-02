using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private float SpawnDelay = 1;
    [SerializeField]
    private bool spawning = false;
    public GameObject[] Gates;

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
            InvokeRepeating("SpawnObstacles", 0, SpawnDelay);
        }

        if (!GameManager.Instance.gameStarted && spawning)
        {
            //Debug.Log("Stop Spawning");
            CancelInvoke("SpawnObstacles");
            spawning = false;
        }  
    }

    private void SpawnObstacles()
    {
        spawning = true;
        SpawnObstacleOrGate();
    }

    private void SpawnObstacleOrGate()
    {
        int i = Random.Range(0, 10);
        if (i <= 7)
        {
            //Debug.Log("Spawn gate");
            SpawnGate();
        }
        else
        {
            //Debug.Log("Spawn obstacle");

            //SpawnObstacle();
        }
    }

    private void SpawnGate()
    {
        int gateInt = Random.Range(0,3);
        if (gateInt == 3) gateInt--;
        Instantiate(Gates[gateInt], transform.position, Gates[gateInt].transform.rotation);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class PlayerController : MonoBehaviour
{

    public GameObject Player;
    public GameObject[] PlayerGO;

    [SerializeField]
    private int currentPlayer;
    private int playerLastFrame;

    // Start is called before the first frame update
    void Start()
    {
        PlayerGO = GameObject.FindGameObjectsWithTag("Player");
        Player = PlayerGO[0];
        currentPlayer = 0;
        UpdatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //wait for player to press a button to start the game
        if (!GameManager.Instance.gameStarted)
        {
            if (Input.anyKeyDown)
            {
                GameManager.Instance.gameStarted = true;
            }
        }

        //Switch between players and use special
        // Q = Red
        // W = Green
        // E = Blue
        // R or Space = Special
        Profiler.BeginSample("Input");
        if (GameManager.Instance.gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentPlayer = 0;
                //Debug.Log("Q pressed");
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                currentPlayer = 1;
                //Debug.Log("W pressed");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentPlayer = 2;
                //Debug.Log("E pressed");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("Space pressed");
                PlayerGO[currentPlayer].GetComponent<Player>().Special();
            }

            if (playerLastFrame != currentPlayer)
            {
                UpdatePlayer();
            }
        }
        Profiler.EndSample();
        
    }

    public void UpdatePlayer()
    {
        foreach(GameObject go in PlayerGO)
        {
            go.SetActive(false);
        }
        PlayerGO[currentPlayer].SetActive(true);
        Player = PlayerGO[currentPlayer];
        playerLastFrame = currentPlayer;
    }
}

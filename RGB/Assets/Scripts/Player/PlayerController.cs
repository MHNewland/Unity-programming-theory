using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class PlayerController : MonoBehaviour
{

    public Player Player;
    public GameObject[] PlayerGO;

    [SerializeField]
    private bool GameStarted = true;
    [SerializeField]
    private int currentPlayer;
    private int playerLastFrame;

    // Start is called before the first frame update
    void Start()
    {
        PlayerGO = GameObject.FindGameObjectsWithTag("Player");
        Player = PlayerGO[0].GetComponent<Player>();
        currentPlayer = 0;
        UpdatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //Update player if player has changed
        //Profiler.BeginSample("Change current player");
        //if (currentPlayer != Player.PlayerColor)
        //{
        //    currentPlayer = Player.PlayerColor;
        //}
        //Profiler.EndSample();

        //Switch between players and use special
        Profiler.BeginSample("Input");
        if (GameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentPlayer = 0;
                Debug.Log("Q pressed");
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                currentPlayer = 1;
                Debug.Log("W pressed");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentPlayer = 2;
                Debug.Log("E pressed");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space pressed");
                Player.Special();
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
        Player = PlayerGO[currentPlayer].GetComponent<Player>();
        playerLastFrame = currentPlayer;
    }
}

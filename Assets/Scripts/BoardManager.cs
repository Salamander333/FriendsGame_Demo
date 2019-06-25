using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public GameObject player_1_model;
    public GameObject player_2_model;

    public int currenPlayerTurn = 1;
    public int player1_init = 0; 
    public int player2_init = 0;
    public bool initFaze = true;

    public Text header;

    public int rolledNumber = 0;

    public GameObject readyPanel;
    public bool gameStarted = false;

    public GameObject player1_panel;
    public GameObject player2_panel;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            header = GameObject.Find("header").GetComponent<Text>();
            readyPanel = GameObject.Find("ReadyPanel");
            player1_panel = GameObject.Find("Player1_Panel");
            player2_panel = GameObject.Find("Player1_Panel");
            readyPanel.SetActive(false);
            player1_panel.SetActive(false);
            player2_panel.SetActive(false);
        }
    }

    void Update()
    {
        if (player1_init != 0 && player2_init != 0 && player1_init != player2_init && !gameStarted)
        {
            initFaze = false;
            if (player1_init > player2_init)
            {
                currenPlayerTurn = 1;
                header.text = $"Player 1 won with {player1_init} against Player 2 ({player2_init})";
            }
            else if (player1_init < player2_init)
            {
                currenPlayerTurn = 2;
                header.text = $"Player 2 won with {player2_init} against Player 1 ({player1_init})";
            }
            readyPanel.SetActive(true);
        }
        else if (player1_init != 0 && player2_init != 0 && player1_init == player2_init && !gameStarted)
        {
            header.text = "Players were tier. Player 1 rolls again.";
            player1_init = 0;
            player2_init = 0;
        }
    }

    public void StartGame()
    {
        readyPanel.SetActive(false);
        if (player1_init > player2_init)
        {
            header.text = "Player 1's turn.";
            player1_panel.SetActive(true);
        }
        else if (player1_init > player2_init)
        {
            header.text = "Player 2's turn.";
            player2_panel.SetActive(true);
        }
    }
}

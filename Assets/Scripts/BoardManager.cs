﻿using System.Collections;
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
    public GameObject rollInitPanel;
    public bool gameStarted = false;

    public GameObject player1;
    public int player1Pos;
    public int player1Score;
    public float player1_offset;

    public GameObject player2;
    public int player2Pos;
    public int player2Score;
    public float player2_offset;

    bool turnEnded;
    public GameObject endTurn;

    public GameObject player1_panel;
    public GameObject player2_panel;

    public BoardBehaviour board;

    void Start()
    {
        DontDestroyOnLoad(this);
        player1_offset = -0.5f;
        player2_offset = 0.5f;
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            board = GameObject.Find("Board").GetComponent<BoardBehaviour>();
            header = GameObject.Find("header").GetComponent<Text>();
            readyPanel = GameObject.Find("ReadyPanel");
            rollInitPanel = GameObject.Find("RollInitPanel");
            player1_panel = GameObject.Find("Player1_Panel");
            player2_panel = GameObject.Find("Player2_Panel");
            readyPanel.SetActive(false);
            player1_panel.SetActive(false);
            player2_panel.SetActive(false);

            var slotsOnField = GameObject.FindGameObjectsWithTag("Slot");
            for (int i = 0; i < board.slots.Length; i++)
            {
                board.slots[i] = slotsOnField[i];
            }

            player1 = Instantiate(player_1_model, new Vector3(board.slots[0].transform.position.x + player1_offset, 0, board.slots[0].transform.position.z + player1_offset), Quaternion.identity);
            player2 = Instantiate(player_2_model, new Vector3(board.slots[0].transform.position.x + player2_offset, 0, board.slots[0].transform.position.z + player2_offset), Quaternion.identity);
            player1Pos = 0;
            player2Pos = 0;

            endTurn = GameObject.Find("EndTurn");
            endTurn.SetActive(false);
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
            rollInitPanel.SetActive(false);
            readyPanel.SetActive(true);
            
        }
        else if (player1_init != 0 && player2_init != 0 && player1_init == player2_init && !gameStarted)
        {
            header.text = "Players were tier. Player 1 rolls again.";
            player1_init = 0;
            player2_init = 0;
        }

        if (currenPlayerTurn == 1 && gameStarted)
        {
            header.text = "Player 1's turn.";
            player1_panel.SetActive(true);
            player2_panel.SetActive(false);
        }
        else if (currenPlayerTurn == 2 && gameStarted)
        {
            header.text = "Player 2's turn.";
            player2_panel.SetActive(true);
            player1_panel.SetActive(false);
        }
    }

    public void StartGame()
    {
        readyPanel.SetActive(false);
        if (player1_init > player2_init)
        {
            currenPlayerTurn = 1;
        }
        else if (player1_init > player2_init)
        {
            currenPlayerTurn = 2;
        }
        gameStarted = true;
    }

    public void MovePlayer(int num)
    {
        switch (currenPlayerTurn)
        {
            case 1:
                if (player1Pos + num > 30)
                {
                    player1.transform.position = new Vector3(board.slots[board.slots.Length - 1].transform.position.x + player1_offset, 0, board.slots[board.slots.Length - 1].transform.position.z + player1_offset);
                    player1Pos = board.slots.Length - 1;
                }
                else
                {
                    var targetSlot = board.slots[player1Pos + num];
                    player1.transform.position = new Vector3(targetSlot.transform.position.x + player1_offset, 0, targetSlot.transform.position.z + player1_offset);
                    player1Pos += num;
                    player1Score += targetSlot.GetComponent<SlotInfo>().scoreToGivePlayer;
                }
                break;
            case 2:
                if (player2Pos + num > 30)
                {
                    player2.transform.position = new Vector3(board.slots[board.slots.Length - 1].transform.position.x + player2_offset, 0, board.slots[board.slots.Length - 1].transform.position.z + player2_offset);
                    player2Pos = board.slots.Length - 1;
                }
                else
                {
                    var targetSlot = board.slots[player2Pos + num];
                    player2.transform.position = new Vector3(targetSlot.transform.position.x + player2_offset, 0, targetSlot.transform.position.z + player2_offset);
                    player2Pos += num;
                    player2Score += targetSlot.GetComponent<SlotInfo>().scoreToGivePlayer;
                    if (targetSlot.GetComponent<SlotInfo>().chanceCard)
                    {

                    }
                }
                break;
        }

        endTurn.SetActive(true);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{
    public BoardManager boardManager;
    public GameObject[] slots;

    void Start()
    {
        boardManager = GameObject.Find("_BoardManager").GetComponent<BoardManager>();
    }

    public void Pressed()
    {
        boardManager.StartGame();
    }

    public void EndTurn()
    {
        if (boardManager.currenPlayerTurn == 1)
        {
            boardManager.currenPlayerTurn = 2;
        }
        else if (boardManager.currenPlayerTurn == 2)
        {
            boardManager.currenPlayerTurn = 1;
        }

        boardManager.endTurn.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Dice"));
    }
}

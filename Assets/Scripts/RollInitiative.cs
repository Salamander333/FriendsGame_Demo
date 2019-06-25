using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollInitiative : MonoBehaviour
{
    private BoardManager boardManager;

    public Text header;

    void Start()
    {
        boardManager = GameObject.Find("_BoardManager").GetComponent<BoardManager>();
        
    }

    void Update()
    {
        if (boardManager.player1_init == 0)
        {
            header.text = "Player 1 rolls for initiative.";
        }
        else if (boardManager.player2_init == 0)
        {
            header.text = "Player 2 rolls for initiative.";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    BoardManager boardManager;

    void Start()
    {
        boardManager = GameObject.Find("_BoardManager").GetComponent<BoardManager>();

        this.gameObject.GetComponent<Text>().text = "Score: 0";
    }

    void Update()
    {
        if (this.gameObject.name == "Score_1")
        {
            this.gameObject.GetComponent<Text>().text = $"Score: {boardManager.player1Score}";
        }
        else if (this.gameObject.name == "Score_2")
        {
            this.gameObject.GetComponent<Text>().text = $"Score: {boardManager.player2Score}";
        }
    }
}

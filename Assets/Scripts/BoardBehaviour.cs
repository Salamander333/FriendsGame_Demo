using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardBehaviour : MonoBehaviour
{
    public BoardManager boardManager;
    public GameObject[] slots;

    public Dictionary<int, string> chanceCards;

    bool drawed = false;

    void Start()
    {
        boardManager = GameObject.Find("_BoardManager").GetComponent<BoardManager>();

        chanceCards = new Dictionary<int, string>();
        chanceCards.Add(0, "Player gains 10 points");
        chanceCards.Add(1, "Opponent gains 10 points");
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
        boardManager.chanceCardPanel.SetActive(false);
    }

    public void DrawChanceCard()
    {
        var card = Random.Range(0, 1);
        boardManager.chanceCardPanel.transform.GetChild(3).GetComponent<Text>().text = $"{chanceCards[card]}";
        switch (card)
        {
            case 0:
                if (boardManager.currenPlayerTurn == 1)
                {
                    boardManager.player1Score += 10;
                }
                else if (boardManager.currenPlayerTurn == 2)
                {
                    boardManager.player2Score += 10;
                }
                break;
            case 1:
                if (boardManager.currenPlayerTurn == 1)
                {
                    boardManager.player2Score += 10;
                }
                else if (boardManager.currenPlayerTurn == 2)
                {
                    boardManager.player1Score += 10;
                }
                break;
        }

        boardManager.endTurn.GetComponent<Button>().interactable = true;
        boardManager.chanceCardPanel.transform.GetChild(1).GetComponent<Button>().interactable = false;
    }
}

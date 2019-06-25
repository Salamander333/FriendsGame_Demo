using System.Collections;
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
}

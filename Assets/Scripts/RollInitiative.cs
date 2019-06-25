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


}

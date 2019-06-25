using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectCharacter : MonoBehaviour
{

    public GameObject[] playerFigures;
    public GameObject slot;
    public GameObject model;
    public int currentSelection;

    private BoardManager boardManager;

    void Start()
    {
        slot = Instantiate(playerFigures[currentSelection], this.transform.position, Quaternion.identity);
        boardManager = GameObject.Find("_BoardManager").GetComponent<BoardManager>();
        SetModel();
    }

    public void SelectPrevious()
    {
        currentSelection--;
        if (currentSelection < 0)
        {
            currentSelection = 3;
        }
        Destroy(slot);
        slot = Instantiate(playerFigures[currentSelection], this.transform.position, Quaternion.identity);

        SetModel();
    }

    public void SelectNext()
    {
        currentSelection++;
        if (currentSelection > 3)
        {
            currentSelection = 0;
        }
        Destroy(slot);
        slot = Instantiate(playerFigures[currentSelection], this.transform.position, Quaternion.identity);
        SetModel();
    }

    void SetModel()
    {
        switch (slot.gameObject.name)
        {
            case "Player_1(Clone)":
                model = playerFigures[0];
                break;
            case "Player_2(Clone)":
                model = playerFigures[1];
                break;
            case "Player_3(Clone)":
                model = playerFigures[2];
                break;
            case "Player_4(Clone)":
                model = playerFigures[3];
                break;
        }

        if (this.gameObject.name == "Player1PrefabPlaceholder")
        {
            boardManager.player_1_model = model;
        }
        else if (this.gameObject.name == "Player2PrefabPlaceholder")
        {
            boardManager.player_2_model = model;
        }
    }
}

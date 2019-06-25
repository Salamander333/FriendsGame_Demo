using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectCharacter : MonoBehaviour
{

    public GameObject[] playerFigures;
    public GameObject slot;
    public int currentSelection;

    void Start()
    {
        slot = Instantiate(playerFigures[currentSelection], this.transform.position, Quaternion.identity);
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
    }

}

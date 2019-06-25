using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll_Dice : MonoBehaviour
{
    public GameObject Dice;
    private Transform Dice_Spawn;

    void Start()
    {
        Dice_Spawn = this.transform;
    }

    public void RollDice()
    {
        if (GameObject.FindGameObjectsWithTag("Dice").Length >= 1)
        {
            var diceToRemove = GameObject.FindGameObjectWithTag("Dice");
            if (diceToRemove.GetComponent<Dice_Behaviour>().Stationary)
            {
                Destroy(diceToRemove);
            }
            
        }
        else
        {
            var dice = Instantiate(Dice, Dice_Spawn.position, Quaternion.identity);
            dice.transform.Rotate(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
        }
    }
}

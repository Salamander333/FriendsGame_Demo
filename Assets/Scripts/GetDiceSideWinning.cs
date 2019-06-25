using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDiceSideWinning : MonoBehaviour
{
    GameObject Dice;
    bool sideSet = false;

    private Dice_Behaviour diceBehaviour;

    void Awake()
    {
        Dice = this.transform.parent.gameObject;
        diceBehaviour = Dice.GetComponent<Dice_Behaviour>();
    }

    void OnTriggerStay(Collider other)
    {
        if (diceBehaviour.Stationary)
        {
            if (other.tag == "Board" && !sideSet)
            {
                switch (this.gameObject.name)
                {
                    case "Side_1":
                        diceBehaviour.SetWinningNumber(6);
                        break;
                    case "Side_2":
                        diceBehaviour.SetWinningNumber(5);
                        break;
                    case "Side_3":
                        diceBehaviour.SetWinningNumber(4);
                        break;
                    case "Side_4":
                        diceBehaviour.SetWinningNumber(3);
                        break;
                    case "Side_5":
                        diceBehaviour.SetWinningNumber(2);
                        break;
                    case "Side_6":
                        diceBehaviour.SetWinningNumber(1);
                        break;
                }

                sideSet = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardClickControl : MonoBehaviour
{
    BoxCollider2D[] cards;
    public void cardClickOff()
    {
        cards = GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D card in cards)
        {
            if (card != null)
            {
                card.enabled = false;
            }
            else
            {
                Debug.Log("card is null");
            }
        }

    }
    public void cardClickOn()
    {
        foreach (BoxCollider2D card in cards)
        {
            if (card != null)
            {
                card.enabled = true;
            }
            else
            {
                Debug.Log("card is null");
            }
        }

    }

}

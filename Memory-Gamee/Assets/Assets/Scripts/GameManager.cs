using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    bool picked; // Set this true if we have 2 cards

    List<Card> pickedCards = new List<Card>();


    private void Awake()
    {
        instance = this;
    }


    public void AddCardToPickedlist(Card card)
    {
        pickedCards.Add(card);
        if(pickedCards.Count == 2)
        {
            picked = true;
            // check if we have a match
        }
    }

    public bool HasPicked()
    {
        return picked;
    }


}

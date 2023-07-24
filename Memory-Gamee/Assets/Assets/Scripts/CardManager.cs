using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public int pairAmount; // if 4 then we will have 8 cards in  the field ;
    public Sprite[] spriteList;

    float offset = 1.2f; // Offset between cards
    public GameObject cardPrefab;



    void Start()
    {
        CreatePlayerField();
    }


    void CreatePlayerField()
    {
        for ( int i = 0; i<pairAmount; i++)
        {
            for (int j = 0; j < 2; j++) // this loop to decide how many time we want to repeat the card
            {

                Vector3 pos = new Vector3(i * offset, 0, 0); // every card position
                GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
                newCard.GetComponent<Card>().SetCard(i, spriteList[i]);
            }
        }
    }
}

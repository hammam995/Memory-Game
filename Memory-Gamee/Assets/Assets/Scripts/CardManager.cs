using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public int pairAmount; // if 4 then we will have 8 cards in  the field ;
    public Sprite[] spriteList;

    float offset = 1.2f; // Offset between cards
    public GameObject cardPrefab;

    public List<GameObject> cardDeck = new List<GameObject>();

    public int width;
    public int height;

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
                Vector3 pos = Vector3.zero;
                GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
                newCard.GetComponent<Card>().SetCard(i, spriteList[i]);
                cardDeck.Add(newCard);
            }
        }


        // SHUFFLE cards , making temporarly variable 3
        for (int i = 0; i < cardDeck.Count; i++)
        {
            int index = Random.Range(0, cardDeck.Count);
            var temp = cardDeck[i];
            cardDeck[i] =  cardDeck[index] ;
            cardDeck[index] = temp;
        }

        // Pass out cards on the field
        int num = 0;

        for(int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {

                Vector3 pos = new Vector3(x * offset, 0 , z * offset);
                cardDeck[num].transform.position = pos;
                num++;
            }
        }
    }




   

    void OnDrawGizmos() // to make the PairAmount and Width , Height equals and not causing errors
    {
        if(pairAmount*2 != width * height)
        {
            Debug.Log("Error : width * height should be pairAmount * 2"); 
        }
        if(pairAmount > spriteList.Length) // if the pairs*2 bigger or no equall to previous condition
        {
            Debug.Log("To much Pairs");
        }
    }
}

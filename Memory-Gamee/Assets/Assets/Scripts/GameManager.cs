using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool picked; // Set this true if we have 2 cards
    bool gameOver;
    List<Card> pickedCards = new List<Card>();
    int pairs;
    int pairCounter;
    public bool hideMatches;

    public int scorePerMatch = 100; 
    


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
            StartCoroutine(CheckMatch());
        }
    }


    IEnumerator CheckMatch() // on case there is match there are 2 options to hide the matches or to keep them appear in the field
    {
        yield return new WaitForSeconds(1.5f);
        if(pickedCards[0].GetCardId() == pickedCards[1].GetCardId())
        {
            // We have a match
            if (hideMatches)
            {
                pickedCards[0].gameObject.SetActive(false);
                pickedCards[1].gameObject.SetActive(false);
            }
            else
            {
                // so camera raycast not hitting the card
                pickedCards[0].GetComponent<BoxCollider>().enabled = false;
                pickedCards[1].GetComponent<BoxCollider>().enabled = false;
            }
            pairCounter++;
            CheckForWin();

            ScoreManager.instance.AddScore(scorePerMatch);



        }
        else
        {
            pickedCards[0].FlipOpen(false);
            pickedCards[1].FlipOpen(false);
            yield return new WaitForSeconds(1.5f);
        }
        // clean up
        picked = false;
        pickedCards.Clear();

        ScoreManager.instance.AddTurn();


    }

    void CheckForWin()
    {
        if(pairs == pairCounter)
        {

            // We won
            Debug.Log("YAY WE WON");

        }

    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Woops we Lost");
    }

    public bool HasPicked()
    {
        return picked;
    }

    public bool GameisOver()
    {
        return gameOver;
    }


    public void SetPairs(int pairAmount)
    {

        pairs = pairAmount;

    }

}

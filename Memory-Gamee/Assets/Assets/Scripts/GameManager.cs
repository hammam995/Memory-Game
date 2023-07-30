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


    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject winEffect;

    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        winEffect.SetActive(false);
    }


    public void AddCardToPickedlist(Card card)
    {
        if (pickedCards.Contains(card)) // to avoid pressing 2 times on the same card if we already had one we exit
        {
            return;
        }
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

            // Activate VFX
            pickedCards[0].ActivateConfetti();
            pickedCards[1].ActivateConfetti();
            // Score
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
            winPanel.SetActive(true);
            winEffect.SetActive(true);
            ScoreManager.instance.StopTimer();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        losePanel.SetActive(true);
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

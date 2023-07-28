using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0) && !GameManager.instance.HasPicked() && !GameManager.instance.GameisOver()) // if we have game over the input will not play
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray , out hit))
            {
                Debug.Log(hit.transform.gameObject);

                Card currentCard = hit.transform.GetComponent<Card>();
                if (currentCard != null)//ADD NULL CHECK HERE
                {
                    currentCard.FlipOpen(true);
                    GameManager.instance.AddCardToPickedlist(currentCard);
                }

                /* Card currentCard = hit.transform.GetComponent<Card>();
                 currentCard.FlipOpen(true);

                 GameManager.instance.AddCardToPickedlist(currentCard);*/
            }
        }
    }
}

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
                Card currentCard = hit.transform.GetComponent<Card>();
                if (currentCard != null)
                {
                    currentCard.FlipOpen(true);
                    GameManager.instance.AddCardToPickedlist(currentCard);
                }
            }
        }
    }
}

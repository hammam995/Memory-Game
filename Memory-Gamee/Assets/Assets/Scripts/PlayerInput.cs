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
        if (Input.GetMouseButtonDown(0) && !GameManager.instance.HasPicked())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray , out hit))
            {
                Debug.Log(hit.transform.gameObject);

                Card currentCard = hit.transform.GetComponent<Card>();
                currentCard.FlipOpen(true);

                GameManager.instance.AddCardToPickedlist(currentCard);
            }
        }
    }
}

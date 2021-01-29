using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Interact!");
        OnInteract();
    }

    public abstract void OnInteract();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.GetComponent<PlayerBehaviour>();
        if(player)
        {
            player.OnInteractableEnter(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.GetComponent<PlayerBehaviour>();
        if (player)
        {
            player.OnInteractableExit(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    static public PlayerBehaviour instance { get;  private set; }

    InteractBehaviour currentInteractable;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Interact(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton() && currentInteractable)
        {
            currentInteractable.Interact();
        }
    }

    public void OnInteractableEnter(InteractBehaviour interactable)
    {
        if(currentInteractable == null)
        {
            currentInteractable = interactable;
            Debug.Log(interactable);
        }
    }

    public void OnInteractableExit(InteractBehaviour interactable)
    {
        if (currentInteractable == interactable)
        {
            currentInteractable = null;
        }
    }
}

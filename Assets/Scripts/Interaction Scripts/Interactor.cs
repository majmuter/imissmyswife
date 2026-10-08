using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable

{
    void Interact();
    void OnTouchingPlayer();
    void OnNotTouchingPlayer();
}

public class Interactor : MonoBehaviour
{

    private IInteractable currentInteractable;

    void Update()
    {
        if (Keyboard.current.eKey.IsActuated() && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable Interactable = collision.GetComponent<IInteractable>();

        if (Interactable != null)
        {
            currentInteractable = Interactable;
            currentInteractable.OnTouchingPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable Interactable = collision.GetComponent<IInteractable>();

        if (Interactable != null)
        {
            currentInteractable.OnNotTouchingPlayer();
            currentInteractable = null; 
        }
    }
}
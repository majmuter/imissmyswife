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
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame && currentInteractable != null)
        {
            currentInteractable.Interact();
            currentInteractable = null;
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

        if (Interactable != null && currentInteractable == Interactable)
        {
            currentInteractable.OnNotTouchingPlayer();
            currentInteractable = null; 
        }
    }
}
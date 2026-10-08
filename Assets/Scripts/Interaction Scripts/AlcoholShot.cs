using UnityEngine;

public class AlcoholShot : MonoBehaviour, IInteractable
{

    public Animator animator;

    public void Interact()
    {
        DrinkAlcohol();
    }

    public void OnNotTouchingPlayer()
    {
        
    }

    public void OnTouchingPlayer()
    {
        
    }

    void DrinkAlcohol()
    {
        animator.SetTrigger("Player_drink");
        Destroy(gameObject);
    }
}
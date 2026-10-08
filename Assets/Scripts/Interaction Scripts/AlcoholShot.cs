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
        animator.SetTrigger("Drinking");
        Destroy(gameObject);
    }
}
using UnityEngine;

public class AlcoholShot : MonoBehaviour, IInteractable
{

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject interactionUI;
    [SerializeField] private AlcoholMeter alcoholMeter;

    public void Interact()
    {
        DrinkAlcohol();
    }

    public void OnNotTouchingPlayer()
    {
        interactionUI.GetComponent<FadeText>().FadeOut();
    }

    public void OnTouchingPlayer()
    {
        interactionUI.GetComponent<FadeText>().FadeIn();
    }

    void DrinkAlcohol()
    {
        playerAnimator.SetTrigger("DrinkAlcohol");
        alcoholMeter.AddAlcohol();
        Destroy(gameObject);

    }
}
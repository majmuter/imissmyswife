using UnityEngine;
using UnityEngine.UI;

public class AlcoholMeter : MonoBehaviour
{
    [SerializeField] private float maxAlcohol = 100f;
    [SerializeField] private float alcoholPerShot = 45f;
    [SerializeField] private float depletionSpeed = 5f;

    [SerializeField] private Image alcoholLevel;

    private float currentAlcohol = 0f;
    private bool hasDrunk = false;

    public bool isEmpty => hasDrunk && currentAlcohol <= 0f;
    public bool hasAlcohol => hasDrunk && currentAlcohol > 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (!hasDrunk || currentAlcohol <= 0f)
        {
            return;
        }

        currentAlcohol -= depletionSpeed * Time.deltaTime;
        currentAlcohol = Mathf.Clamp(currentAlcohol, 0f, maxAlcohol);

        UpdateBar();
    }

    public void AddAlcohol()
    {
        hasDrunk = true;

        currentAlcohol = Mathf.Min(currentAlcohol + alcoholPerShot, maxAlcohol);

        UpdateBar();
    }

    void UpdateBar()
    {
        alcoholLevel.fillAmount = currentAlcohol / maxAlcohol;
    }
}

using UnityEngine;
using UnityEngine.UI; // Required for accessing UI components

public class TimerBar : MonoBehaviour
{
    [SerializeField] private Image barImage; // Drag your Filled Image here
    [SerializeField] private float maxTime = 5f; // Total time in seconds

    private float timeLeft;

    void Start()
    {
        // Start the bar at full capacity
        timeLeft = maxTime;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            // Reduce time elapsed since last frame
            timeLeft -= Time.deltaTime;

            // Fill Amount expects a fraction between 0.0 and 1.0
            barImage.fillAmount = timeLeft / maxTime;
        }
        else
        {
            timeLeft = 0;
        }
    }
}
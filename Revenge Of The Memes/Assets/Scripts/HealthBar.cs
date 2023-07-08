using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    Player playerBehavior;
    public TextMeshProUGUI killsCounterText;
    public Slider heathSlider;

    // Start is called before the first frame update
    void Start()
    {
        playerBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBehavior != null)
        {
            heathSlider.value = playerBehavior.health;
            killsCounterText.SetText("Kills: " + GameManager.enemiesKilled.ToString());
        }
    }
}

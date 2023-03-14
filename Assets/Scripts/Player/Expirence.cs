using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Text healthText;
    private int health = 100;

    void Start()
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        UpdateHealthText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("monster1"))
        {
            health -= 10;
            healthSlider.SetValueWithoutNotify(health);
            UpdateHealthText();
        }
        else if (other.gameObject.CompareTag("monster2"))
        {
            health -= 20;
            healthSlider.SetValueWithoutNotify(health);
            UpdateHealthText();
        }

        if (health <= 0)
        {
            EndGame();
        }
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + Mathf.RoundToInt((float)health / healthSlider.maxValue * 100) + "%";
    }

    void EndGame()
    {
        // Code ð? k?t thúc game
    }
}

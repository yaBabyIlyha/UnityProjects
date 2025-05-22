using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.rectTransform.localScale = new Vector3(currentHealth / maxHealth, 1, 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(10);
    }
}
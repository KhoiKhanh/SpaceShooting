using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public RectTransform healthBarValue;

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (healthBarValue != null)
        {
            float target = (float)currentHealth / maxHealth;
            healthBarValue.anchorMax = new Vector2(target, 1f);
        }
    }
}

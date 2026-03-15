using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    // Hàm này được dùng trong các phiên bản cũ hơn của tài liệu.
    // public void OnTriggerEnter2D(Collider2D collision) => Die();
    public UnityEvent<int, int> onHealthChanged;
    public int defaultHealthPoint; // Máu mặc định (set trong Inspector)
    private int healthPoint; // Máu hiện tại

    private void Start() 
    {
        healthPoint = defaultHealthPoint;
        onHealthChanged?.Invoke(healthPoint, defaultHealthPoint);
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;
        healthPoint -= damage;
        onHealthChanged?.Invoke(healthPoint, defaultHealthPoint);
        if (healthPoint <= 0) Die(); // Chết nếu máu <= 0
    }

    public void Heal(int amount)
    {
        if (healthPoint <= 0) return;
        healthPoint += amount;
        if (healthPoint > defaultHealthPoint) healthPoint = defaultHealthPoint;
        onHealthChanged?.Invoke(healthPoint, defaultHealthPoint);
    }

    protected virtual void Die()
    {
        var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 1);
        Destroy(gameObject);
        onDead?.Invoke();
    }
}
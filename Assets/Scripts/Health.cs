using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    // Hàm này được dùng trong các phiên bản cũ hơn của tài liệu.
    // public void OnTriggerEnter2D(Collider2D collision) => Die();
     public int defaultHealthPoint; // Máu mặc định (set trong Inspector)
    private int healthPoint; // Máu hiện tại

 private void Start() => healthPoint = defaultHealthPoint;

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;
        healthPoint -= damage;
        if (healthPoint <= 0) Die(); // Chết nếu máu <= 0
    }

    protected virtual void Die()
    {
        var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 1);
        Destroy(gameObject);
    }
}
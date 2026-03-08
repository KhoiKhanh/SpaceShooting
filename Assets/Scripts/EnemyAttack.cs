using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack: MonoBehaviour
{
    public static int LivingEnemyCount;
    private void Awake() => LivingEnemyCount++;

protected override void Die()
{
LivingEnemyCount--;
base.Die();
}
    public EnemyHealth health; // Tham chiếu đến script máu của chính kẻ thù
    public int damage; // Sát thương gây ra cho người chơi

    private void OnTriggerEnter2D (Collider2D collision)
    {
        var playerHealth = collision.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage (damage); // Gây sát thương cho Player
            health.TakeDamage(1000); // Kẻ thù tự hủy (máu lớn hơn mọi giá trị)
        }
    }
}
public class EnemyBullet : Bullet
{
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(ChanceCrit());
            gameObject.SetActive(false);
        }
    }
}

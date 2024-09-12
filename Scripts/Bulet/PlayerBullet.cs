public class PlayerBullet : Bullet 
{
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(ChanceCrit());
            gameObject.SetActive(false);
        }
    }
}
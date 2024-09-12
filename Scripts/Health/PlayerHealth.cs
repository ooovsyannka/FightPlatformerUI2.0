using UnityEngine;

public class PlayerHealth : Health
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Medkit medkit))
        {
            Regenerate(medkit.CountToRecovery);
            medkit.gameObject.SetActive(false);
        }
    }
}
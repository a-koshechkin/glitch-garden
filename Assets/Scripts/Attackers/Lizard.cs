using UnityEngine;

public class Lizard : Attacker
{
    #region Monobehavior

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackIfDefender(collision.gameObject);
    }

    #endregion
}

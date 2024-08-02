using UnityEngine;

public class Fox : Attacker
{
    #region Monobehavior

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<Gravestone>() != null)
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }
        else
        {
            AttackIfDefender(collision.gameObject);
        }
    }

    #endregion
}


using UnityEngine;

public class Gravestone : MonoBehaviour
{
    #region MonoBehaviour

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {

        }
    }

    #endregion
}

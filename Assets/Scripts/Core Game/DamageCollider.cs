using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    #region MonoBehaviour

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LivesDisplay>().TakeLife();
        collision.gameObject.SetActive(false);
        Destroy(collision.gameObject);
    }

    #endregion
}

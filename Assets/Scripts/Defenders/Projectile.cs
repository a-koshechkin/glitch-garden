using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _damage = 40f;

    private readonly float _speed = 5f;

    #endregion

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_damage < 0 )
        {
            _damage = 0f;
        }
    }

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attacker"))
        {
            collision.GetComponent<Health>().DealDamage(_damage);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    #endregion
}

using UnityEngine;

public class Health : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _deathVFX;
    [SerializeField] private float _health = 100f;

    private float _currentHealth;
    private Vector3 _correction = new (-0.8f, -0.4f, 0);

    private const string VFX_PARENT_NAME = "VFX parent";

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        _currentHealth = _health;
    }

    private void OnValidate()
    {
        if (_health < 0)
        {
            _health = 1f;
        }
    }

    #endregion

    #region Methods

    public void DealDamage(float damage)
    {
        _currentHealth -= damage;

        if ( _currentHealth <= 0 )
        {
            TriggerDeathVFX();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        var vfxObject = Instantiate(_deathVFX, transform.position + _correction, transform.rotation);
        vfxObject.transform.parent = GetVfxParent();
        Destroy(vfxObject, 2);
    }

    private Transform GetVfxParent()
    {
        var parent = GameObject.Find(VFX_PARENT_NAME);
        if (parent == null)
        {
            parent = new GameObject(VFX_PARENT_NAME);
        }
        return parent.transform;
    }

    #endregion
}

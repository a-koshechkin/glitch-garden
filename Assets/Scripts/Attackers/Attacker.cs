using UnityEngine;

public class Attacker : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _currentSpeed = 1.5f;
    private Defender _target;

    private const float MIN_SPEED = 0.1f;
    private const float MAX_SPEED = 10f;

    #endregion

    #region MonoBehaviour
    private void OnValidate()
    {
        if (_currentSpeed < MIN_SPEED)
        {
            _currentSpeed = MIN_SPEED;
        }
        if (_currentSpeed > MAX_SPEED)
        {
            _currentSpeed = MAX_SPEED;
        }
    }
    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();    
    }

    void Update()
    {
        transform.Translate(_currentSpeed * Time.deltaTime * Vector2.left);
        UpdateAnimation();
    }

    private void OnDestroy()
    {
        var levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerRemoved();
        }
    }

    #endregion

    #region Methods

    private void UpdateAnimation()
    {
        if (_target == null) {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void Attack(Defender target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        _target = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (_target == null)
        {
            return;
        }

        var health = _target.GetComponent<Health>();
        if (health != null)
        {
            health.DealDamage(damage);
        }
    }

    protected void AttackIfDefender(GameObject potentialDefender)
    {
        if (potentialDefender != null)
        {
            var defender = potentialDefender.GetComponent<Defender>();
            if (defender != null)
            {
                GetComponent<Attacker>().Attack(defender);
            }
        }
    }

    #endregion
}

using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _gun;

    private AttackerSpawner _myLaneSpawner;
    private Animator _animator;

    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (HasAttackerInLane())
        {
            _animator.SetBool("IsAttacking", true);
        }
        else
        {
            _animator.SetBool("IsAttacking", false);
        }
    }

    #endregion

    #region Methods

    public void Fire()
    {
        var projectile = Instantiate(_projectile, _gun.position, Quaternion.identity);
        projectile.transform.parent = GetProjectileParent();
    }

    private Transform GetProjectileParent()
    {
        var parent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (parent == null)
        {
            parent = new GameObject(PROJECTILE_PARENT_NAME);
        }
        return parent.transform;
    }

    private void SetLaneSpawner()
    {
        foreach (var spawner in FindObjectsOfType<AttackerSpawner>())
        {
            if (Math.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon)
            {
                _myLaneSpawner = spawner;
                return;
            }
        }
    }

    private bool HasAttackerInLane()
    {
        if (_myLaneSpawner != null)
        {
            return _myLaneSpawner.transform.childCount > 0;
        }
        else
        {
            return false;
        }
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private List<Attacker> _attackerPrefabs;

    [SerializeField] private float _minSpawnDelay = 3f;
    [SerializeField] private float _maxSpawnDelay = 8f;

    private bool _isSpawning = true;
    private Vector3 _spawnCorrection = new(0, 0.5f, 0);

    private const float MIN_SPAWN_DELAY = 0.5f;
    private const float MAX_SPAWN_DELAY = 15f;

    #endregion

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_minSpawnDelay < MIN_SPAWN_DELAY || _minSpawnDelay > MAX_SPAWN_DELAY)
        {
            _minSpawnDelay = MIN_SPAWN_DELAY;
        }

        if (_maxSpawnDelay > MAX_SPAWN_DELAY || _maxSpawnDelay < MIN_SPAWN_DELAY)
        {
            _maxSpawnDelay = MAX_SPAWN_DELAY;
        }

        if (_minSpawnDelay > _maxSpawnDelay)
        {
            _minSpawnDelay = MIN_SPAWN_DELAY;
        }
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(FindObjectOfType<GameTimer>().TimerStartDelay, FindObjectOfType<GameTimer>().TimerStartDelay + _maxSpawnDelay));
        while (_isSpawning)
        {
            SpawnAttacker();
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
        }
    }

    #endregion

    #region Methods

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, _attackerPrefabs.Count);
        var attacker = Instantiate(_attackerPrefabs[attackerIndex], transform.position + _spawnCorrection, transform.rotation);
        attacker.transform.parent = transform;
    }

    public void StopSpawning()
    {
        _isSpawning = false;
    }

    #endregion
}

using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject _winLevelCanvas;
    [SerializeField] GameObject _loseLevelCanvas;

    private int _numberOfAttackersOnTheField = 0;
    private bool _isLevelTimerFinished = false;

    private const float _nextLevelLoadTime = 5f;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        _winLevelCanvas.SetActive(false);
        _loseLevelCanvas.SetActive(false);
    }

    #endregion

    #region Methods

    public void AttackerSpawned()
    {
        _numberOfAttackersOnTheField++;
    }

    public void AttackerRemoved()
    {
        _numberOfAttackersOnTheField--;
        if (_numberOfAttackersOnTheField <= 0 && _isLevelTimerFinished && FindObjectOfType<LivesDisplay>().Lives > 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        _winLevelCanvas.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(_nextLevelLoadTime);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        _loseLevelCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LevelTimerFinished()
    {
        _isLevelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        foreach (var spawner in FindObjectsOfType<AttackerSpawner>())
        {
            spawner.StopSpawning();
        }
        if (_numberOfAttackersOnTheField <= 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    #endregion
}

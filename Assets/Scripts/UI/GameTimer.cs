using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _levelTime = 20f;
    [SerializeField] private float _timerStartDelay = 3f;

    private AudioSource _timerFinishedAudio;
    private bool _timerFinished = false;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        _timerFinishedAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        var timeSinceTimerStart = Time.timeSinceLevelLoad - _timerStartDelay;
        if (!_timerFinished && timeSinceTimerStart >= 0)
        {
            var slider = GetComponent<Slider>();
            slider.value = timeSinceTimerStart / _levelTime;
            if (timeSinceTimerStart > _levelTime)
            {
                _timerFinishedAudio.Play();
                _timerFinished = true;
                GetComponentInChildren<Animator>().SetBool("TimerFinished", true);
                var levelControleer = FindObjectOfType<LevelController>();
                if (levelControleer != null)
                {
                    levelControleer.LevelTimerFinished();
                }
            }
        }
    }

    #endregion
}

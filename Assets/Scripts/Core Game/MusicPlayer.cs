using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    #region Fields

    private AudioSource _audioSource;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        DontDestroyOnLoad(this);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    #endregion

    #region Methods

    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }

    #endregion
}

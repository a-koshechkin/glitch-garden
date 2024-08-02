using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _difficultySlider;

    private MusicPlayer _musicPlayer;

    private const float _defaultVolume = 0.8f;
    private const float _defaultDifficulty = 0f;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        _musicPlayer = FindObjectOfType<MusicPlayer>();
        _volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        _difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        if (_musicPlayer != null)
        {
            _musicPlayer.SetVolume(_volumeSlider.value);
        }
    }

    #endregion

    #region Methods

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(_volumeSlider.value);
        PlayerPrefsController.SetDifficulty(_difficultySlider.value);
        FindObjectOfType<SceneLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        _volumeSlider.value = _defaultVolume;
        _difficultySlider.value = _defaultDifficulty;
    }

    #endregion
}

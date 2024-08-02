using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _baseLives = 5;

    private float _lives;
    private TextMeshProUGUI _livesText;

    #endregion

    #region Properties

    public float Lives => _lives;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        _lives = _baseLives - PlayerPrefsController.GetDifficulty();
        _livesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    #endregion

    #region Methods

    private void UpdateDisplay()
    {
        _livesText.text = _lives.ToString();
    }

    public void TakeLife()
    {
        _lives--;

        if (_lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
        else
        {
            UpdateDisplay();
        }
    }

    #endregion
}

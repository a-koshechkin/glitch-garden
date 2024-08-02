using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    #region Fields

    [SerializeField] private int _stars = 300;

    private TextMeshProUGUI _starText;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        _starText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    #endregion

    #region Methods

    private void UpdateDisplay()
    {
        _starText.text = _stars.ToString();
    }

    public void AddStars(int stars)
    {
        _stars += stars;
        UpdateDisplay();
    }

    public void SpendStars(int stars)
    {
        if (HasEnoughStars(stars))
        {
            _stars -= stars;
            UpdateDisplay();
        }
    }

    public bool HasEnoughStars(int stars)
    {
        return _stars >= stars;
    }

    #endregion
}

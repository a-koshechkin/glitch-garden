using Unity.Android.Types;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    #region Fields

    [SerializeField] private Defender _defenderPrefab;

    private DefenderSpawner _spawner;

    private Color32 _inactiveColor = new(42, 42, 42, 255);
    private Color32 _activeColor = Color.white;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        var cost = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        if (cost != null)
        {
            cost.text = _defenderPrefab.StarCost.ToString();
        }
    }

    private void OnMouseDown()
    {
        foreach (var button in FindObjectsOfType<DefenderButton>())
        {
            button.GetComponent<SpriteRenderer>().color = _inactiveColor;
        }
        GetComponent<SpriteRenderer>().color = _activeColor;
        if (_spawner == null)
        {
            _spawner = FindObjectOfType<DefenderSpawner>();
        }
        _spawner.SetSelectedDefender(_defenderPrefab);
    }

    #endregion
}

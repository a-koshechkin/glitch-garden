using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private Transform _defenderHolder;

    private Defender _defender;
    private const float _precision = 0.1f;

    #endregion

    #region MonoBehaviour

    private void OnMouseDown()
    {
        if (_defender != null)
        {
            AttemptToPlaceDefenderAt(GetSquareClicked());
        }
    }

    #endregion

    #region Methods

    private void SpawnDefender(Vector3 position)
    {
        var defender = Instantiate(_defender, position, Quaternion.identity);
        defender.transform.parent = _defenderHolder;
    }

    private Vector2 GetSquareClicked()
    {
        return SnapToGrid(Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)));
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        return new Vector2(Mathf.RoundToInt(rawWorldPos.x), Mathf.RoundToInt(rawWorldPos.y));
    }

    public void SetSelectedDefender(Defender defender)
    {
        _defender = defender;
    }

    private void AttemptToPlaceDefenderAt(Vector2 position)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        var defenderCost = _defender.StarCost;
        if (starDisplay.HasEnoughStars(defenderCost) && !IsCellTaken(position))
        {
            SpawnDefender(position);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private bool IsCellTaken(Vector2 position)
    {
        var defenders = FindObjectsOfType<Defender>();
        foreach (var defender in defenders)
        {
            if ((defender.transform.position - new Vector3(position.x, position.y, defender.transform.position.z)).magnitude < _precision)
            {
                return true;
            }
        }
        return false;
    }

    #endregion
}

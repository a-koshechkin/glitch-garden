using UnityEngine;

public class Defender : MonoBehaviour
{
    #region Fields

    [SerializeField] private int _starCost = 100;

    #endregion

    #region Properties

    public int StarCost => _starCost;

    #endregion

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_starCost < 0)
        {
            _starCost = 1;
        }
    }

    #endregion
}

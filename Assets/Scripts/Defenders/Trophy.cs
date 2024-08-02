public class Trophy : Defender
{
    #region Methods

    public void AddStars(int stars)
    {
        FindObjectOfType<StarDisplay>().AddStars(stars);
    }

    #endregion
}

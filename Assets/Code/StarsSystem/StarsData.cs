using UnityEngine;

[CreateAssetMenu(menuName = "StarsSystem/Data")]
public class StarsData : ScriptableObject
{
    public Sprite[] stars;

    public Sprite GetStarsCount(int starsCount)
    {
        return stars[starsCount];
    }
}

using System;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public Action<int> OnStarsChange;
    public int stars;

    private void Awake()
    {
        stars = PlayerPrefs.GetInt("Stars", 0);
    }

    public void AddStars(int stars)
    {
        this.stars += stars;
        PlayerPrefs.SetInt("Stars", this.stars);
        OnStarsChange?.Invoke(this.stars);
    }

    public void TakeStars(int stars)
    {
        this.stars -= stars;
        PlayerPrefs.SetInt("Stars", this.stars);
        OnStarsChange?.Invoke(this.stars);
    }
}

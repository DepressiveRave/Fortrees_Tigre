using System;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public Action<int> OnHealthChange;
    public int health;

    public void ApplyDamage(int Damage)
    {
        health -= Damage;
        OnHealthChange?.Invoke(health);
    }
}

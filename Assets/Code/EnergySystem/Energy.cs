using System;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public event Action<int> OnEnergyChange;
    public int energy;
    public void AddEnergy(int value)
    {
        energy += value;
        OnEnergyChange?.Invoke(energy);
    }

    public void TakeEnergy(int value)
    {
        energy -= value;
        OnEnergyChange?.Invoke(energy);
    }
}

using System;
using Lean.Pool;
using UnityEngine;

public class SkillSpawn : MonoBehaviour
{
    public Action<bool> OnSkillSpawnActivate;
    private bool isActive = false;
    [SerializeField] LeanGameObjectPool[] leanGameObjectPool;

    public void Get()
    {
        SetIsActive(true);
    }

    public void Use(int ID)
    {
        if (!GetIsActive()) return;

        // Получаем позицию клика
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0f; // Устанавливаем Z координату на 0, чтобы объект был на переднем плане
        leanGameObjectPool[ID].Spawn(clickPosition);
    }


    public bool GetIsActive()
    {
        return isActive;
    }

    public void SetIsActive(bool isActive)
    {
        this.isActive = isActive;
        OnSkillSpawnActivate?.Invoke(this.isActive);
    }
}

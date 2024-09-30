using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy Stats/Data")]
public class EnemyData : ScriptableObject
{
    public float HealthValue;
    public int earnEnergyValue;
    public float SpeedValue;
}

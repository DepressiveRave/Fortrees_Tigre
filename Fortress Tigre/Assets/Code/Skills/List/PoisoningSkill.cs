using Lean.Pool;
using UnityEngine;
using Zenject;

public class PoisoningSkill : SKill
{
    [SerializeField] SkillsList skillsList;
    private int skillLevel;

    [Header("Poison Data")]
    [SerializeField] PoisonDebuffData[] PoisonDebuffData;
    [Inject] SkillSpawn skillSpawn;

    private void Awake()
    {
        skillLevel = PlayerPrefs.GetInt("SkillLevel_" + skillsList.ToString());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Enemy>())
        {
            Seek(collision.transform);
        }

        if (collision.GetComponent<Transform>().Equals(getTarget()))
        {
            ApplyDebuff();
        }
    }

    private void ApplyDebuff()
    {
        Enemy target = getTarget().GetComponent<Enemy>();
        if (target != null)
        {
            target.AddBuff(new PoisonDebuff(PoisonDebuffData[skillLevel], getTarget().gameObject));
        }
    }

    public void StarSkillEvent()
    {
        skillSpawn.SetIsActive(false);
    }

    public void EndSkillEvent()
    {
        LeanPool.Despawn(gameObject);
    }
}

using Lean.Pool;
using UnityEngine;
using Zenject;

public class StopTimeSkill : SKill
{
    [SerializeField] SkillsList skillsList;
    private int skillLevel;
    [Header("SlowEffect Setting")]
    [SerializeField] SlowdownDebuffData[] SlowdownDebuff;
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
            target.AddBuff(new SlowdownDebuff(SlowdownDebuff[skillLevel], getTarget().gameObject));
        }
    }

    public void StarSkillEvent()
    {
        SoundPlayer.Instance.PlaySound("StopTimeSkill");
        skillSpawn.SetIsActive(false);
    }

    public void EndSkillEvent()
    {
        LeanPool.Despawn(gameObject);
    }
}

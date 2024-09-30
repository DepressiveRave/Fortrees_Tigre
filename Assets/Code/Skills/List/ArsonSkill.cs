using UnityEngine;
using Lean.Pool;
using Zenject;

public class ArsonSkill : SKill
{
    [SerializeField] float[] _Damage;
    [SerializeField] SkillsList skillsList;
    private int skillLevel;

    [Header("Fire Data")]
    [SerializeField] FireDebuffData[] fireDebuffData;
    [Inject] SkillSpawn skillSpawn;

    private void Awake()
    {
        skillLevel = PlayerPrefs.GetInt("SkillLevel_" + skillsList.ToString());
        setDamage(_Damage[skillLevel]);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Enemy>())
        {
            Seek(collision.transform);
        }

        if (collision.GetComponent<Transform>().Equals(getTarget()))
        {
            HitTarget();
            ApplyDebuff();
        }
    }

    private void ApplyDebuff()
    {
        Enemy target = getTarget().GetComponent<Enemy>();
        if (target != null)
        {
            target.AddBuff(new FireDebuff(fireDebuffData[skillLevel], getTarget().gameObject));
        }
    }

    public void StarSkillEvent()
    {
        SoundPlayer.Instance.PlaySound("ArsonSkill");
        skillSpawn.SetIsActive(false);
    }

    public void EndSkillEvent()
    {
        LeanPool.Despawn(gameObject);
    }
}

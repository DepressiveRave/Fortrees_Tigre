using Lean.Pool;
using UnityEngine;
using Zenject;

public class LightningStrikeSkill : SKill
{
    [SerializeField] float[] _Damage;
    [SerializeField] SkillsList skillsList;
    private int skillLevel;
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
        }
    }

    public void StarSkillEvent()
    {
        SoundPlayer.Instance.PlaySound("LightningSkill");
        skillSpawn.SetIsActive(false);
    }

    public void EndSkillEvent()
    {
        LeanPool.Despawn(gameObject);
    }
}

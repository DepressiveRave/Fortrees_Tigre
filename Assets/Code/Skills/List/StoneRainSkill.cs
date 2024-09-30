using Lean.Pool;
using UnityEngine;
using Zenject;

public class StoneRainSkill : SKill
{
    [SerializeField] float[] _Damage;
    [SerializeField] SkillsList skillsList;
    private int skillLevel;
    [Inject] SkillSpawn skillSpawn;
    Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
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

    public void EnableColliderEvent()
    {
        collider.enabled = true;
    }

    public void StarSkillEvent()
    {
        SoundPlayer.Instance.PlaySound("StoneRainSkill");
        skillSpawn.SetIsActive(false);
    }

    public void EndSkillEvent()
    {
        collider.enabled = false;
        LeanPool.Despawn(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.FantasyMonsters.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{

    [Header("Unity Stuff")]
    public Image hitpointBar;

    //  public List<Debuff> debuffs = new List<Debuff>();
    private float hitpoint;
    private float speed;
    private bool isDead = false;
    private int earnEnergy;


    // private Animator anim;
    [SerializeField] Monster monster;
    //private const string IS_DEAD = "isDead";
    // private const string IS_WALK = "isWalk";

    [SerializeField] public EnemyData enemyData;
    [Inject] private Energy _energy;

    private readonly Dictionary<ScriptableBuff, TimedBuff> _buffs = new Dictionary<ScriptableBuff, TimedBuff>();

    private void Awake()
    {
        SetData();
        isDead = false;
        //anim = GetComponentInChildren<Animator>();
        monster.SetState(MonsterState.Walk);
        //anim.SetTrigger(IS_WALK);
    }

    void Update()
    {
        HandlerDebuffs();
    }

    private void SetData()
    {
        SetSpeed(enemyData.SpeedValue);
        SetHitpoint(enemyData.HealthValue);
        SetEarnEnergy(enemyData.earnEnergyValue);
        hitpointBar.fillAmount = 1;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetEarnEnergy(int earnEnergy)
    {
        this.earnEnergy = earnEnergy;
    }

    public int GetEarnEnergy()
    {
        return this.earnEnergy;
    }

    public void SetHitpoint(float hitpoint)
    {
        this.hitpoint = hitpoint;
    }

    public float GetHitpoint()
    {
        return hitpoint;
    }

    public bool GetIsDead()
    {
        return isDead;
    }


    public void TakeDamage(float amount)
    {
        hitpoint -= amount;

        hitpointBar.fillAmount = hitpoint / enemyData.HealthValue;

        if (hitpoint <= 0 && !isDead)
        {
            Die();
        }

    }

    public void Die()
    {
        SoundPlayer.Instance.PlaySound("Hit");
        this.gameObject.tag = "Untagged";
        SetSpeed(0);
        _energy.AddEnergy(GetEarnEnergy());
        isDead = true;
        Destroy(gameObject);
    }

    public void AnimationEventDeath()
    {
        SetSpeed(0);
        SetData();
        Destroy(gameObject);
    }

    public void AddBuff(TimedBuff buff)
    {
        if (_buffs.ContainsKey(buff.Buff))
        {
            _buffs[buff.Buff].Activate();
        }
        else
        {
            _buffs.Add(buff.Buff, buff);
            buff.Activate();
        }
    }

    public void HandlerDebuffs()
    {
        foreach (var buff in _buffs.Values.ToList())
        {
            buff.Tick(Time.deltaTime);
            if (buff.IsFinished)
            {
                _buffs.Remove(buff.Buff);
            }
        }
    }
}

using StateMachine.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerData : CharacterBase
{
    #region serialize
    [Header("Movement")]
    public float speed;
    public float friction;
    [Header("Aim")]
    public bool autoAim;
    public float autoAimRange;
    [Header("Dash")]
    public KeyCode dodgeKeyboard;
    public Key dodgeKey;
    public float dodgeDuration;
    public float dodgeSpeed;
    public float dodgeCooldown;
    [Header("SlowMotion")]
    [SerializeField][Range(0f, 1f)] public float slowMoPercent;
    public float timeForSlowMo;
    [Header("StandardSkill")]
    public BulletBase bullet;
    public float cooldown;
    [Header("Sequence")]
    public float timeForSequence;
    public SetSequencesData[] sequences;
    [SerializeField] GameplaySM gameplaySM;
    #endregion

    float _slowMoRemainTime;
    [HideInInspector] public float slowMoRemainTime
    {
        get { return _slowMoRemainTime; }
        set {
            OnSlowMoUse?.Invoke(value);
            _slowMoRemainTime = value;
        }
    }

    public System.Action OnSlowMoStarted;
    public System.Action<float> OnSlowMoUse;
    public System.Action OnRefilled;
    public System.Action OnChangeSequences;

    protected override void Awake()
    {
        base.Awake();
        base.OnDeath += OnDeath;
    }

    public void ChangeSkill(List<SetSequencesData> datas)
    {
        sequences = new SetSequencesData[datas.Count];
        sequences = datas.ToArray();
        OnChangeSequences?.Invoke();
    }

    private void OnDeath(IDamageable _damageable)
    {
        StartCoroutine(OnDeathLate());
    }

    IEnumerator OnDeathLate()
    {
        Stop(1.5f);
        yield return new WaitForSeconds(1.5f);
        gameplaySM.Go("Lose");
    }
}
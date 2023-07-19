using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFootStep : EnemyAbstract
{
    const string EVENT_STEP_NAME = "stepdown";

    protected override void Awake()
    {
        base.Awake();
        this.LoadFootStepEventRegister();
    }

    protected virtual void LoadFootStepEventRegister()
    {
        this.enemyCtrl.AnimationEvent.OnCustomEvent += this.OnCustomEventOfPlayer;
    }

    protected virtual void OnCustomEventOfPlayer(string eventName)
    {
        if (eventName != EnemyFootStep.EVENT_STEP_NAME) return;

        AudioClip audioClip = this.enemyCtrl.EnemySO.WalkStep();
        SoundSpawner.Instance.PlayEffect(audioClip, transform.position, transform.rotation);
    }
}

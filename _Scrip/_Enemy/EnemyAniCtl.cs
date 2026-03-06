using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAniCtl : ObjOn1
{
    [SerializeField] protected EnemyCtl enemyCtl;
    [SerializeField] protected Animator Ani;
    public Animator Animator => Ani;

    protected override void Loadcomponents()
    {
        base.Loadcomponents();
        this.LoadAnimator();
        this.LoadPlayerCtl();
    }

     protected virtual void LoadPlayerCtl()
    {
        if(this.enemyCtl != null) return;
        this.enemyCtl = transform.GetComponent<EnemyCtl>();
    }

    protected void LoadAnimator()
    {
        if(this.Ani != null) return;
        this.Ani = transform.GetComponent<Animator>();
    }

    public virtual void SetAnimation()
    {
        bool isRuning = Mathf.Abs(enemyCtl.Rigi.velocity.x) > 0.01f;
        this.Ani.SetBool("_Run",isRuning);
    }
}

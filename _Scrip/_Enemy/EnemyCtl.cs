using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtl : ObjOn1
{
    [SerializeField]protected Rigidbody2D rigi;
    public Rigidbody2D Rigi => rigi;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected EnemyAniCtl AniCtl;
    public EnemyAniCtl Animator => AniCtl;

    protected override void Loadcomponents()
    {
        base.Loadcomponents();
        this.LoadRigidbody();
        this.LoadCollider();
        this.LoadAniCtl();
    }

    protected void LoadRigidbody()
    {
        if(this.rigi != null) return;
        this.rigi = transform.GetComponent<Rigidbody2D>();
    }

    protected virtual void LoadCollider()
    {
        if(this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    protected void LoadAniCtl()
    {
        if(this.AniCtl != null) return;
        this.AniCtl = transform.GetComponent<EnemyAniCtl>();
    }
}

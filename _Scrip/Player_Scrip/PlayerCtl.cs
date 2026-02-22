using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtl : ObjOn1
{
    [SerializeField]protected Rigidbody2D rigi;
    public Rigidbody2D Rigi => rigi;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Animator Ani;
    public Animator Animator => Ani;
    [SerializeField]protected Transform groundCheck;
    public Transform GroundCheck => groundCheck;

    protected override void Loadcomponents()
    {
        base.Loadcomponents();
        this.LoadRigidbody();
        this.LoadCollider();
        this.LoadAnimator();
        this.LoadGround();
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
    protected void LoadAnimator()
    {
        if(this.Ani != null) return;
        this.Ani = transform.GetComponent<Animator>();
    }

    protected void LoadGround()
    {
        if(this.groundCheck != null) return;
        this.groundCheck = transform.Find("GroundCheck");
    }
}

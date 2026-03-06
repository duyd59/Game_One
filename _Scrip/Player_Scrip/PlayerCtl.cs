using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtl : ObjOn1
{
    [SerializeField]protected Rigidbody2D rigi;
    public Rigidbody2D Rigi => rigi;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected PlayerAniCtl AniCtl;
    public PlayerAniCtl Animator => AniCtl;
    [SerializeField]protected Transform groundCheck;
    public Transform GroundCheck => groundCheck;
    public bool ClimbCondition;
    [SerializeField]protected bool isGround;
    public bool IsGround => isGround;
    [SerializeField]protected DameSender dameSender;
    public DameSender Damesend => dameSender;
    [SerializeField]protected LayerMask LayerCondition;


    protected override void Loadcomponents()
    {
        base.Loadcomponents();
        this.LoadRigidbody();
        this.LoadCollider();
        this.LoadAniCtl();
        this.LoadGround();
        this.LoadDamesender();
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
        this.AniCtl = transform.GetComponent<PlayerAniCtl>();
    }

    protected void LoadGround()
    {
        if(this.groundCheck != null) return;
        this.groundCheck = transform.Find("GroundCheck");
        this.LayerCondition =LayerMask.GetMask("Ground");
    }

    protected virtual void LoadDamesender()
    {
        if(this.dameSender != null) return;
        this.dameSender = transform.GetComponentInChildren<DameSender>();
    }
    public virtual void SetAnimation(){
        this.AniCtl.SetAnimation();
    }

    protected virtual void OnTriggerEnter2D(Collider2D colli)
    {
        if (colli.transform.CompareTag("Climb"))
        {
            this.ClimbCondition = true;
            this.rigi.gravityScale = 0f;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D colli)
    {
        if (colli.transform.CompareTag("Climb"))
        {
            this.ClimbCondition = false;
            this.rigi.gravityScale = 1f;
        }
    }

    protected virtual void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            this.dameSender.SendDame(coll.gameObject);
        }
    }

    public virtual void SetGround()
    {
        this.isGround = Physics2D.OverlapCircle(GroundCheck.position,0.2f,LayerCondition);
    }

    public virtual void SetIsGround()
    {
        this.isGround = true;
    }


}

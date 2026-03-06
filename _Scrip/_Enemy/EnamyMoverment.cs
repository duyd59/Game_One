using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyMoverment : ObjOn1
{
    [SerializeField]protected EnemyCtl enemyCtl;
    [SerializeField]protected LayerMask layerMask;
    [SerializeField]protected Vector3 Vtmove = Vector3.right;

    protected override void Loadcomponents()
    {
        base.Loadcomponents();
        this.LoadEnemyCtl();
    }

    protected virtual void LoadEnemyCtl()
    {
        if(this.enemyCtl != null) return;
        this.enemyCtl = transform.parent.GetComponent<EnemyCtl>();
    }
    protected virtual void Update()
    {
        if(!this.StartvsRaycast()) return;
        this.EnemyMoving();
    }

    protected virtual void EnemyMoving()
    {
        if (this.CheckvsRaycast())
        {
            this.enemyCtl.Animator.SetAnimation();
            this.enemyCtl.Rigi.velocity = this.Vtmove;
        }
    }

    protected virtual bool StartvsRaycast()
    {
        Vector3 OriginPos = transform.parent.position;
        this.layerMask = LayerMask.GetMask("Ground");
        if (Physics2D.Raycast(OriginPos, transform.parent.TransformDirection(Vector3.down),0.5f,this.layerMask))
        {
            return true;
        }
        return false;
    }

    protected virtual bool CheckvsRaycast()
    {
        Vector3 OriginPos = transform.parent.position;
        this.layerMask = LayerMask.GetMask("Ground");
        Vector2 RayAway = new Vector2(transform.parent.lossyScale.x,0);
        if (Physics2D.Raycast(OriginPos, transform.parent.TransformDirection(RayAway),0.5f,this.layerMask))
        {
            this.ChangeFace();
            this.Vtmove *= -1;
            Debug.DrawRay(transform.parent.position, RayAway, Color.red); 
            return false;
        }
        Debug.DrawRay(transform.parent.position, RayAway * 0.5f, Color.green);
        return true;
    }

    protected virtual void ChangeFace()
    {
        transform.parent.localScale = new Vector3(transform.parent.localScale.x *-1,transform.parent.localScale.y,transform.parent.localScale.z);
    }
}

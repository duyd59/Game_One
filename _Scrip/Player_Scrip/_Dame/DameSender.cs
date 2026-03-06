using System.Collections;
using System.Collections.Generic;
using Cinemachine.Editor;
using UnityEngine;

public class DameSender : ObjOn1
{
    [SerializeField] protected PlayerCtl playerCtl;
    [SerializeField]protected int Dame = 1;
    protected override void Loadcomponents()
    {
        base.Loadcomponents();
        this.LoadPlayerCtl();
    }

    protected virtual void LoadPlayerCtl()
    {
        if(this.playerCtl != null) return;
        this.playerCtl = transform.GetComponentInParent<PlayerCtl>();
    }
    public virtual void SendDame(GameObject GOBj)
    {
        DameReceiver dameReceiver= GOBj.GetComponentInChildren<DameReceiver>();
        if(dameReceiver != null)
        {
            if(InputManager.Instance.LeftMouse) dameReceiver.DameReceive(this.Dame);
        }
    }
}

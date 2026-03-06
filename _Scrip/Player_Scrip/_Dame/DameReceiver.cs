using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameReceiver : ObjOn1
{
    [SerializeField]protected int currentHp;
    public int CurrentHp => currentHp;

    [SerializeField]protected int Maxhp;
    public int MaxHp => Maxhp;
    protected override void Loadcomponents()
    {
        base.Loadcomponents();
        this.LoadHp();
    }

    protected virtual void LoadHp()
    {
        this.currentHp = this.Maxhp;
    }

    protected virtual int HealHp(int Heal)
    {
        if(this.currentHp >= this.Maxhp) return this.currentHp = this.Maxhp;
        return this.currentHp+=Heal;
    }
    public virtual void DameReceive(int dame)
    {
        if(this.currentHp <= 0){
            this.currentHp = 0;
            Debug.Log("you dead");
        }
        this.currentHp-=dame;
    }
}

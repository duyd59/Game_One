using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOn1 : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.Loadcomponents();
    }

    protected virtual void Reset()
    {
        this.Loadcomponents();
    }

    protected virtual void Loadcomponents(){}
}

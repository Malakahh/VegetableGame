using UnityEngine;
using System.Collections.Generic;

public abstract class Effect : MonoBehaviour {
    public delegate void EffectDelegate(VegetableSlot slot);
    public static event EffectDelegate OnEffectSuccess;

    public VegetableSlot AssignedSlot;
    public List<KeyCode> strokes = new List<KeyCode>();
    protected int checkIncrementer = 0;
    public abstract void ReleaseToObjectPool();

    public virtual void Check()
    {
        if (checkIncrementer < strokes.Count && Input.GetKey(strokes[checkIncrementer]))
        {
            checkIncrementer++;

            if (checkIncrementer == strokes.Count && OnEffectSuccess != null)
            {
                checkIncrementer = 0;
                OnEffectSuccess(AssignedSlot);
            }
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public abstract class Effect : MonoBehaviour {
    public Material IconMaterial;
    protected List<KeyCode> strokes = new List<KeyCode>();
    protected int checkIncrementer = 0;

    public virtual void Check()
    {
        if (checkIncrementer < strokes.Count)
        {
            if (Input.GetKey(strokes[checkIncrementer]))
            {
                checkIncrementer++;

                if (checkIncrementer == strokes.Count)
                {
                    Debug.Log("Key Combination accepted!");
                }
            }
        }
    }
}

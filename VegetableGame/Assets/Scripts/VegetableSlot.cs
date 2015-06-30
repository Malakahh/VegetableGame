using UnityEngine;
using System.Collections;

public class VegetableSlot : MonoBehaviour {
    public GameObject Vegetable;
    public Effect Effect;

    void Update()
    {
        if (Effect != null)
        {
            Effect.Check();
        }
    }
}

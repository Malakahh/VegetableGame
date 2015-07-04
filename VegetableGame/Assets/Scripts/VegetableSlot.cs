using UnityEngine;
using System.Collections;

public class VegetableSlot : MonoBehaviour {
    public GameObject Vegetable;
    public Effect Effect;
    bool playerIsNear = false;

    void Update()
    {
        if (playerIsNear && Effect != null)
        {
            Effect.Check();
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        playerIsNear = true;
    }

    void OnTriggerExit2D(Collider2D c)
    {
        playerIsNear = false;
    }
}

using UnityEngine;
using System.Collections.Generic;

public class VegetableManager : MonoBehaviour {
    public List<GameObject> PossibleVegetables = new List<GameObject>();
    public float VegetableSpread = 0.2f;

    GameObject ground;
    private List<VegetableSlot> slots = new List<VegetableSlot>();

    void Start()
    {
        ground = GameObject.FindGameObjectWithTag("Ground");
        SpawnSlots();
        SpawnVegetables();
    }

    void SpawnSlots()
    {
        VegetableSlot tempSlot = ObjectPool.Acquire<VegetableSlot>();
        float bound = ground.transform.localScale.x * 0.5f - tempSlot.transform.localScale.x * 0.5f;
        float step = tempSlot.transform.localScale.x + VegetableSpread;
        float offset = ((bound * 2) % step) * 0.5f;
        Vector3 pos = Vector3.zero;
        ObjectPool.Release<VegetableSlot>(tempSlot);

        //Continuesly place slots until we run out of space
        for (pos.x = -bound + offset; pos.x < bound; pos.x += step)
        {
            VegetableSlot s = ObjectPool.Acquire<VegetableSlot>();
            s.transform.position = pos;
            slots.Add(s);
        }
    }

    void SpawnVegetables()
    {
        foreach (VegetableSlot s in slots)
        {
            Vegetable v = ObjectPool.Acquire<Vegetable>();
            v.transform.position = s.transform.position;
            s.Vegetable = v.gameObject;
        }
    }
}

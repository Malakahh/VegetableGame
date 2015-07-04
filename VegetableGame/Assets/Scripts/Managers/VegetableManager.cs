using UnityEngine;
using System.Collections.Generic;

public class VegetableManager : MonoBehaviour {
    public static VegetableManager Instance;

    public List<GameObject> PossibleVegetables = new List<GameObject>();
    public float VegetableSpread = 0.2f;

    [HideInInspector]
    public List<VegetableSlot> slots = new List<VegetableSlot>();

    GameObject ground;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        ground = GameObject.FindGameObjectWithTag("Ground");
        SpawnSlots();
        SpawnVegetables();
        EffectManager.Instance.Begin();
    }

    void SpawnSlots()
    {
        float bound = ground.transform.localScale.x * 0.5f - 0.5f;
        float step = VegetableSpread + 1;
        float offset = ((bound * 2) % step) * 0.5f;

        //Continuesly place slots until we run out of space
        for (float x = -bound + offset; x < bound; x += step)
        {
            VegetableSlot s = ObjectPool.Acquire<VegetableSlot>();
            s.transform.position = new Vector3(x, 0, 0);
            slots.Add(s);
            s.gameObject.SetActive(true);
        }
    }

    void SpawnVegetables()
    {
        foreach (VegetableSlot s in slots)
        {
            Vegetable v = ObjectPool.Acquire<Vegetable>();
            v.transform.position = s.transform.position;
            s.Vegetable = v.gameObject;
            v.gameObject.SetActive(true);
        }
    }
}

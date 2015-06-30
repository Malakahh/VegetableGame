using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {
    public static EffectManager Instance;
    public VegetableSlot hi;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Test()
    {
        hi.Effect = ObjectPool.Acquire<Thirsty>();
        hi.Effect.gameObject.SetActive(true);
    }
}

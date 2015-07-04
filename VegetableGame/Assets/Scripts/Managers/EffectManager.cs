using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {
    public static EffectManager Instance;
    public float RefreshFrequency = 1f;
    public int MaxNaiveAttemps = 3;

    bool begun = false;
    float timer = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Effect.OnEffectSuccess += Effect_OnEffectSuccess;
    }

    void Effect_OnEffectSuccess(VegetableSlot slot)
    {
        slot.Effect.gameObject.SetActive(false);
        slot.Effect.ReleaseToObjectPool();
        slot.Effect = null;
    }

    public void Begin()
    {
        begun = true;
    }

    void FixedUpdate()
    {
        if (begun)
        {
            timer += Time.fixedDeltaTime;

            if (timer >= 1 / RefreshFrequency)
            {
                for (int i = 0; i < MaxNaiveAttemps; i++)
                {
                    VegetableSlot slot = VegetableManager.Instance.slots[Random.Range(0, VegetableManager.Instance.slots.Count)];

                    //Make sure we have a valid slot
                    if (slot != null && slot.Vegetable != null && slot.Effect == null)
                    {
                        slot.Effect = ObjectPool.Acquire<Thirsty>() as Effect;
                        slot.Effect.transform.position = slot.transform.position;
                        slot.Effect.AssignedSlot = slot;
                        slot.Effect.gameObject.SetActive(true);
                        break;
                    }
                }

                timer = 0;
            }
        }
    }
}

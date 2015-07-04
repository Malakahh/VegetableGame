using UnityEngine;
using System.Collections.Generic;

public class EffectArrowController : MonoBehaviour {
    public Sprite Left;
    public Sprite Down;
    public Sprite Right;
    public Sprite Up;

    List<EffectArrow> arrows = new List<EffectArrow>();

    Sprite KeyCodeToSprite(KeyCode code)
    {
        if (code == KeyCode.LeftArrow)
        {
            return Left;
        }
        else if (code == KeyCode.DownArrow)
        {
            return Down;
        }
        else if (code == KeyCode.RightArrow)
        {
            return Right;
        }
        else
        {
            return Up;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        VegetableSlot slot = c.GetComponent<VegetableSlot>();
        if (slot.Effect != null && slot != null)
        {
            float bound = slot.Effect.strokes.Count / 2;
            float spacingStep = 1.2f;
            float offset = ((bound * 2) % spacingStep) * 0.5f;

            for (int i = 0; i < slot.Effect.strokes.Count; i++)
            {
                float x = -bound + offset + spacingStep * i;

                EffectArrow a = ObjectPool.Acquire<EffectArrow>();
                a.transform.parent = this.transform;
                a.transform.localPosition = new Vector3(x, 1, 0);
                a.GetComponent<SpriteRenderer>().sprite = KeyCodeToSprite(slot.Effect.strokes[i]);
                a.gameObject.SetActive(true);
                arrows.Add(a);
            }
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        foreach (EffectArrow a in arrows)
        {
            a.gameObject.SetActive(false);
            ObjectPool.Release<EffectArrow>(a);
        }

        arrows.Clear();
    }
}

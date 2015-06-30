using UnityEngine;
using System.Collections;

public class Thirsty : Effect {
    void Awake()
    {
        this.strokes.Add(KeyCode.LeftArrow);
        this.strokes.Add(KeyCode.DownArrow);
        this.strokes.Add(KeyCode.RightArrow);
        this.strokes.Add(KeyCode.UpArrow);
    }
}

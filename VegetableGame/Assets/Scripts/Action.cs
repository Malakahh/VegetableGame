using UnityEngine;
using System.Collections.Generic;

public class Action : MonoBehaviour {
    public List<KeyCode> Strokes = new List<KeyCode>();

    bool start = false;
    int currentStrokeIndex = 0;

    public void Run()
    {
        start = true;
    }

    void Update()
    {
        if (start)
        {
            if (currentStrokeIndex < Strokes.Count)
            {
                if (Input.GetKey(Strokes[currentStrokeIndex]))
                {
                    currentStrokeIndex++;
                }
            }
            else
            {
                Debug.Log("Action complete, yay!");
                start = false;
            }
        }
    }
}

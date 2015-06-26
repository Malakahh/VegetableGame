using UnityEngine;
using System.Collections.Generic;

public class Vegetable : MonoBehaviour {
    Action a;

    void Start()
    {
        a = Instantiate<Action>(ActionManager.Instance.Actions[0]);
        a.Run();
    }
}

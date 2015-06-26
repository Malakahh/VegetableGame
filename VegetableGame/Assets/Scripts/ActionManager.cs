using UnityEngine;
using System.Collections.Generic;

public class ActionManager : MonoBehaviour {
    public static ActionManager Instance;

    public List<Action> Actions = new List<Action>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}

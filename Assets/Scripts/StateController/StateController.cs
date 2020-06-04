using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField]List<string> States;
    [SerializeField] string First;
    
    State Current = new State();


    void Awake()
    {
        Set(First);
    }

    public string Get()
    {
        return Current.Name;
    }


    public void Set(string _name)
    {
        foreach(string State in States)
        {
            if(_name == State)
            {
                Current.Name = _name;
            }
        }
    }

}

public struct State
{
    public State(string _name)
    {
        Name = _name;
    }

    public string Name;
}

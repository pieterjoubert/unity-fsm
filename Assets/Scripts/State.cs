using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State {

    public string Name { get; set; }
    private List<Transition> transitions;
    public GameObject gameObject;
    private delegate void methodToRun();
    private State next;
    public State(string name) {
        Name = name;
        transitions = new List<Transition>();
    }
    
    public void addTransition(Condition c, State s)
    {
        transitions.Add(new Transition(c,s));
    }

    public bool checkForTransition(string name, object rhs)
    {
        foreach(Transition t in transitions)
        {
            if(t.condition.name == name && t.condition.check(rhs))
            {
                next = t.nextState;
                return true;
            }
        }
        return false;
    }

    public State getNextState(){
        return next;
    }
}

public struct Transition {
    public Condition condition;
    public State nextState;

    public Transition(Condition c, State s)
    {
        condition = c;
        nextState = s;
    }

    public override string ToString()
    {
        return condition.ToString() + " " + nextState.Name;
    }
}

public class Condition {
    private object lhs;
    public string name;

    public Condition(string n, object l)
    {
        name = n;
        lhs = l;
    }

    public bool check(object rhs)
    {
        if(lhs.Equals(rhs)) {
            return true;
        }
        return false;
    }

    public override string ToString() {
        return name + " " + lhs.ToString();
    }
}
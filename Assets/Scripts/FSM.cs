using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour {

	public List<State> states;
	State current;
	State start;
	State end;
	public string name;
	// Use this for initialization
	void Awake () {
		current = new State("current");
		name = "";
		Debug.Log("Set Name:" + current.Name);
//		StartCoroutine("stateBuilder");
	}

	IEnumerator stateBuilder()
	{
		foreach(State s in states) {

			yield return null;
		}
	}

	public List<State> BuildStateList()
	{
		states = new List<State>();
		current = new State("current start");
		states.Add(current);
		return states;
	}

	// Update is called once per frame
	void Update () {
		bool check = false;
		if(Input.GetKey(KeyCode.Return)) {check = true;}
		if(current.checkForTransition("check1", check))
		{
			current = current.getNextState();
			Debug.Log(current.Name);
		}
	}

}

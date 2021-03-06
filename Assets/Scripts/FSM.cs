﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour {

	private State[] states;
	State current;
	State start;
	State end;
	public string name;
	// Use this for initialization
	void Start () {
		name = "";
		State temp = new State("1");
		State temp2 = new State("2");
		temp.addTransition(new Condition("check1", true), temp2);
		temp2.addTransition(new Condition("check2", true), temp);
		current = temp;
		Debug.Log("Set Name:" + current.Name);
//		StartCoroutine("stateBuilder");
	}

	IEnumerator stateBuilder()
	{
		foreach(State s in states) {

			yield return null;
		}
	}

	public List<State> GetStateList()
	{
		List<State> states = new List<State>();
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

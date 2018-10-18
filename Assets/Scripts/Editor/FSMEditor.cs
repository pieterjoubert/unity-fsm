using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FSMEditor : EditorWindow {

	private string stateName;
	private string paramName;
	private string condition;
	private string conditionName;
	private string nextState;
	private GameObject go;	
	private GameObject actionGo;
	private FSM fsm;
	private bool transitionsAdded = false;
	private List<State> states;

	[MenuItem ("FSM/FSM Editor")]
    public static void  ShowWindow () {
        EditorWindow.GetWindow(typeof(FSMEditor));
    }

	void OnGUI () {
		EditorGUILayout.LabelField ("FSM Object:", EditorStyles.boldLabel);
		go = (GameObject)EditorGUILayout.ObjectField(go, typeof(GameObject), true);
		if(go != null)
		{
			fsm = go.GetComponent<FSM>();
			//fSM.GetState();
			fsm.name = EditorGUILayout.TextField("Name:", fsm.name);
			EditorGUILayout.LabelField ("States:", EditorStyles.boldLabel);
			states = fsm.GetStateList();
			Debug.Log("State #: " + states.Count);
			foreach(State s in states) {
				s.Name = EditorGUILayout.TextField("State Name:", s.Name);
			}
			
			//actionGo = (GameObject)EditorGUILayout.ObjectField("Action GO:", actionGo, typeof(GameObject), true);

			EditorGUILayout.LabelField ("New Transition:", EditorStyles.boldLabel);
			conditionName = EditorGUILayout.TextField("Condition Name:", conditionName);
			condition = EditorGUILayout.TextField("Condition:", condition);
			nextState = EditorGUILayout.TextField("Next State:", nextState);
			/* if (GUILayout.Button("Add Transition"))
			{
				tempTransition.Add(new Transition(new Condition(conditionName, condition), new State(nextState)));
				transitionsAdded = true;
				Debug.Log("Trying to repaint");
			}
			EditorGUILayout.Space();
			if(transitionsAdded) {
				EditorGUILayout.LabelField ("Transitions:", EditorStyles.boldLabel);
				foreach(Transition t in tempTransition)
				{
					EditorGUILayout.LabelField (t.ToString());
				}
			}*/
		}
	}

	void Update()
	{
		
	}


}
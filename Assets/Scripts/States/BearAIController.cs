using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearAIController : MonoBehaviour 
{
	public float sightRange = 20f;
	public Transform[] wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3 (0,.5f,0);
	public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
	public NavMeshAgentController navMeshAgent;
	[HideInInspector]
	public Transform chaseTarget;

	private BearStateBase currentState;
	private Dictionary<BearState, BearStateBase> states;

	private void Awake ()
	{
		states = new Dictionary<BearState, BearStateBase> ();
		states.Add (BearState.Patrol, new PatrolState (this));
		states.Add (BearState.Alert, new AlertState (this));
		states.Add (BearState.Chase, new ChaseState (this));
		currentState = states [BearState.Patrol];
	}
	
	private void Update () 
	{
		currentState.UpdateState ();
	}

	public void MakeTransition (BearState state)
	{
		Debug.Log (state);
		currentState = states[state];
		currentState.StartState ();
	}

	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter (other);
	}
}

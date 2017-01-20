using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class NavMeshAgentController : MonoBehaviour 
{

	private NavMeshAgent agent;
	private Animator animator;

	private bool isMoving;

	private void Awake ()
	{
		// Get references to components, shouldn't be null because of RequireComponent attribute
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
	}
	
	private void Update () 
	{
		SyncAnimation ();
	}

	public void SetDestination(Vector3 destination)
	{
		// Set the agents new destination
		agent.destination = destination;
	}

	private void SyncAnimation ()
	{
		// Set speed parameter in animator
		bool isMoving = CheckIsMoving ();
		float speed = isMoving? 1f : 0f;
		animator.SetFloat ("Speed", speed);
	}

	private bool CheckIsMoving ()
	{
		// Check if agent reached last node and the distance inside the node is close enough to the target
		return agent.pathPending || agent.remainingDistance > agent.stoppingDistance;
	}
}

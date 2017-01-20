using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class SimpleAgent : MonoBehaviour 
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
	
	private void Update () {
		// Check for input
		if (Input.GetButtonDown ("Fire1"))
			SetDestination ();

		SyncAnimation ();
	}

	private void SetDestination()
	{
		// Construct a ray from the current mouse coordinates and check for ground
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (ray, out hit))
		{
			// Set agent destination to start pathfinding
			agent.destination = hit.point;
		}
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

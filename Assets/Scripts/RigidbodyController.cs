using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Animator))]
public class RigidbodyController : MonoBehaviour 
{
	private NavMeshAgent agent;
	private new Rigidbody rigidbody;
	private Animator animator;

	private void Awake ()
	{
		// Get references to components, shouldn't be null because of RequireComponent attribute
		agent = GetComponent<NavMeshAgent> ();
		rigidbody = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}
	
	private void Start ()
	{
		// Setup NavMeshAgent so it doesn't move the character
		agent.updatePosition = false;
	}

	private void Update () 
	{
		// The path is recalculated every frame, and the movement can be more complex: dash, climb, etc.
		Debug.Log (agent.desiredVelocity);
		rigidbody.velocity = agent.desiredVelocity;
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

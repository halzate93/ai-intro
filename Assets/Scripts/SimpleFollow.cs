using UnityEngine;

[RequireComponent (typeof (NavMeshAgentController))]
public class SimpleFollow : MonoBehaviour 
{
	[SerializeField]
	private Transform target;
	[SerializeField]
	private float threshold = 4f;
	private NavMeshAgentController agentController;

	private void Awake ()
	{
		agentController = GetComponent<NavMeshAgentController> ();
	}
	
	private void Update () 
	{
		// Check every frame if the target is too far
		if (CheckIsTooFar ())
			agentController.SetDestination (target.position);	
	}

	private bool CheckIsTooFar ()
	{
		// Get distance and compare
		Vector3 direction = target.position - transform.position;
		return direction.magnitude > threshold;
	}
}

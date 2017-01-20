using UnityEngine;

[RequireComponent (typeof (NavMeshAgentController))]
public class SimpleAgent : MonoBehaviour 
{
	private NavMeshAgentController agentController;

	private void Awake ()
	{
		// Get references to components, shouldn't be null because of RequireComponent attribute
		agentController = GetComponent<NavMeshAgentController> ();
	}
	
	private void Update () {
		// Check for input
		if (Input.GetButtonDown ("Fire1"))
			SetDestination ();
	}

	private void SetDestination()
	{
		// Construct a ray from the current mouse coordinates and check for ground
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (ray, out hit))
		{
			// Set agent destination to start pathfinding
			agentController.SetDestination(hit.point);
		}
	}
}

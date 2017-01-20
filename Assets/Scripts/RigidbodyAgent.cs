using UnityEngine;

[RequireComponent (typeof (RigidbodyController))]
public class RigidbodyAgent : MonoBehaviour 
{
	private RigidbodyController rigidbodyController;

	private void Awake ()
	{
		rigidbodyController = GetComponent<RigidbodyController> ();
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
			rigidbodyController.SetDestination(hit.point);
		}
	}
}

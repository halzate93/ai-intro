using UnityEngine;

public class ChaseState : BearStateBase
{
    public ChaseState(BearAIController controlled) : base(controlled)
    {
    }

    public override void UpdateState()
    {
        Chase ();
		Look ();
    }


    private void Look()
    {
        Transform player = LookForPlayer ();
		if (player != null)
			controlled.chaseTarget = player;
		else
            ToAlert ();
    }

    private void Chase ()
    {
		controlled.navMeshAgent.SetDestination(controlled.chaseTarget.position);
		if (IsCloseEnough ())
			GameObject.Destroy (controlled.chaseTarget.gameObject);
    }

	private bool IsCloseEnough ()
	{
		return (controlled.chaseTarget.position - controlled.transform.position).magnitude < 1;
	}

	private void ToAlert ()
	{
		controlled.chaseTarget = null;
		controlled.MakeTransition (BearState.Alert);
	}
}

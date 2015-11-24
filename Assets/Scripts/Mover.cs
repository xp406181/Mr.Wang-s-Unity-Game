using UnityEngine;
using System.Collections;

public class Mover : GameObj {
	public float speed;

	private Rigidbody boltRB = null;
	private const string boundaryTag = "Boundary";
	private const string ownPlayerTag = "OwnPlayer";

	void Start () 
	{
		boltRB = transform.GetComponent<Rigidbody>();
		boltRB.velocity = transform.forward * speed;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == boundaryTag)
		{
			return ;
		}
		
		if(other.tag == ownPlayerTag)
		{
			return;
		}

		GameObj otherObj = other.transform.GetComponent<GameObj>();

		base.UnderAttack(otherObj.Attack);
		
		if(base.LiveState == false)
		{

			Destroy(gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class Mover : GameObj {
	public float speed;

	private Rigidbody boltRB = null;
	private const string boundaryTag = "Boundary";
	private const string ownPlayerTag = "OwnPlayerTag";

	void Start () 
	{
		boltRB = transform.GetComponent<Rigidbody>();
		boltRB.velocity = transform.forward * speed;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == boundaryTag)
		{
			return ;
		}
		
		if(other.name == ownPlayerTag)
		{
			return;
		}

		GameObj otherObj = other.transform.GetComponent<GameObj>();

		base.UnderAttack(otherObj.Attack);
		Debug.Log(string.Format("name:{0},livestate:{1}",name,base.LiveState));
		
		if(base.LiveState == false)
		{
			Destroy(gameObject);
		}
	}
}

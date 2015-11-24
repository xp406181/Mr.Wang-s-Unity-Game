using UnityEngine;
using System.Collections;

public class DestroyByContact : GameObj {
	public GameObject AsteroidExplosion;
	private string boundaryTag = "Boundary";

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == boundaryTag)
		{
			return ;
		}

		GameObj otherObj = other.transform.GetComponent<GameObj>();
		
		base.UnderAttack(otherObj.Attack);

	

		if(base.LiveState == false)
		{
			Instantiate(AsteroidExplosion,transform.position,transform.rotation);
			Destroy(gameObject);
		}
	}
	void Update()
	{

	}
}

using UnityEngine;
using System.Collections;

public class DestroyByContact : GameObj {
	public GameObject AsteroidExplosion;
	private string boundaryTag = "Boundary";

	void OnTriggerEnter(Collider other)
	{
		if(other.name == boundaryTag)
		{
			return ;
		}

		GameObj otherObj = other.transform.GetComponent<GameObj>();
		
		base.UnderAttack(otherObj.Attack);

		Debug.Log(string.Format("name:{0},livestate:{1}",name,base.LiveState));

		if(base.LiveState == false)
		{
			Instantiate(AsteroidExplosion,transform.position,transform.rotation);
			Destroy(gameObject);
		}
	}
	void Update()
	{
//		Debug.Log(string.Format("name:{0},livestate:{1}",name,base.LiveState));
	}
}

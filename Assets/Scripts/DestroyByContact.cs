using UnityEngine;
using System.Collections;

public class DestroyByContact : GameObj {
	public GameObject AsteroidExplosion;
	public int Score;
	private AsteRoidController m_GameController;
	private string boundaryTag = "Boundary";

	void Start()
	{
		GameObject obj = GameObject.FindGameObjectWithTag("GameController");
		
		if(obj != null)
		{
			m_GameController = obj.GetComponent<AsteRoidController>();
		}

		if(m_GameController == null)
		{
			Debug.Log("Can't find AsteRoidController SCRIPT");
		}
	}

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
			m_GameController.AddScore(Score);
			Instantiate(AsteroidExplosion,transform.position,transform.rotation);
			Destroy(gameObject);
		}
	}
	void Update()
	{

	}
}

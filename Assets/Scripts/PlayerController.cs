using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Boundary{
	public float xMin,xMax,zMin,zMax;
}

public class PlayerController : GameObj {
	public float VerticalSpeed = 1.0f;
	public float HorizontalSpeed = 1.0f;
	public float Tilt = 1.0f;
	public float FireSpeed = 1.0f;
	public Boundary Boundary;
	public GameObject Shot;
	public GameObject PlayerExplosion;

	private Transform shotSpawn;
	private Transform playerTrans = null;
	private Rigidbody playerRB = null;
	private bool fireFlag = false;
	private float nextFire = 0.0f;
	private const string boundaryTag = "Boundary";
	private const string OwnBoltTag = "OwnBolt";

	void Start()
	{
		playerTrans = transform;
		playerRB = playerTrans.GetComponent<Rigidbody> ();
		shotSpawn = playerTrans.Find("ShotSpawn");

		if(Shot != null)
		{
			fireFlag = true;
		}
	}

	void Update()
	{
		if(fireFlag && Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + 1 / FireSpeed;
			GameObject bolt = Instantiate(Shot,shotSpawn.position,shotSpawn.rotation) as GameObject;
			bolt.tag = OwnBoltTag;
		}
//		Debug.Log(string.Format("name:{0},livestate:{1}",name,base.LiveState));
	}

	void FixedUpdate()
	{

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
	
		playerRB.velocity = new Vector3(moveHorizontal * HorizontalSpeed,0.0f,moveVertical * VerticalSpeed);

		playerRB.position = new Vector3
		(
			Mathf.Clamp (playerRB.position.x, Boundary.xMin, Boundary.xMax),
			0.0f,
			Mathf.Clamp (playerRB.position.z, Boundary.zMin, Boundary.zMax)
		);

		playerRB.rotation = Quaternion.Euler (0.0f, 0.0f, playerRB.velocity.x * -Tilt);
	}
		
	void OnTriggerEnter(Collider other)
	{
		if(other.name == boundaryTag)
		{
			return ;
		}

		if(other.name == OwnBoltTag)
		{
			return;
		}

		GameObj otherObj = other.transform.GetComponent<GameObj>();
		Debug.Log(other.name);
		base.UnderAttack(otherObj.Attack);
		Debug.Log(string.Format("name:{0},livestate:{1}",name,base.LiveState));

		if(base.LiveState == false)
		{
			Instantiate(PlayerExplosion,playerTrans.position,playerTrans.rotation);
			Destroy(gameObject);
		}
	}
}

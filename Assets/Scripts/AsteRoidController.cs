using UnityEngine;
using System.Collections;

public class AsteRoidController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 SpawnValue;
	public int HazardCount;
	public float SpawnWait;

	// Use this for initialization
	void Start () {
		if(hazard == null)
		{
			return;
		}
		StartCoroutine(SpawnWaves());
	}
	
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(SpawnWait);

		while(true)
		{
			for (int i = 0; i < HazardCount; i++) 
			{
				float x = Random.Range(-SpawnValue.x,SpawnValue.x);
				Vector3 spawnPosition = new Vector3(x,SpawnValue.y,SpawnValue.z);
				Quaternion spawnRoatation = Quaternion.identity;
				Instantiate(hazard,spawnPosition,spawnRoatation);
				yield return new WaitForSeconds(SpawnWait);
			}
		}

	}
}

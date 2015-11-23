using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	public float Tumble = 1f;

	private Rigidbody Asteroid;

	// Use this for initialization
	void Start () {
		Asteroid = transform.GetComponent<Rigidbody>();
		Asteroid.angularVelocity = Random.insideUnitSphere * Tumble;
	}
}

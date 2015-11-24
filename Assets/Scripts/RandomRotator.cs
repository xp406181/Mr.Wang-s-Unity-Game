using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	public float Tumble = 1f;
	public float Speed = 1f;

	private Rigidbody Asteroid;

	// Use this for initialization
	void Start () {
		Asteroid = transform.GetComponent<Rigidbody>();
		Asteroid.angularVelocity = Random.insideUnitSphere * Tumble;
		Asteroid.velocity = -transform.forward * Speed;
	}
}

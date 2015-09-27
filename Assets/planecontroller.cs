using UnityEngine;
using System.Collections;

public class planecontroller : MonoBehaviour {

	private Vector3 rot = new Vector3(0,0,0);
	private string content;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rot.x = Input.acceleration.y * 90f;
		rot.y = 0f;
		rot.z = -Input.acceleration.x * 90f;
		transform.eulerAngles = rot;
	}
	void OnGUI (){
		content = "rotation:" + transform.eulerAngles.x + "-" + transform.eulerAngles.y + "-" + transform.eulerAngles.z;
		GUI.Label (new Rect(10,100,180,20),content);
	}
}

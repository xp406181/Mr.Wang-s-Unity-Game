using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private Vector3 ballpos;
	private Vector3 newtouchpos;
	private Vector2 touchpos;
	private GUIContent content;
	private float centerx;
	private float centery;
	public Camera cam;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		content = new GUIContent();
		centerx = (float)Screen.width / 2;
		centery = (float)Screen.height / 2;
		transform.position = new Vector3 (0, 0.5f, 0);

	}
	
	// Update is called once per frame
	void FixedUpdate() {
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");

		if (Input.touchCount == 1) {
			touchpos = Input.touches[0].position;
			newtouchpos = cam.ScreenToWorldPoint(new Vector3(touchpos.x,touchpos.y,35));
			ballpos = transform.position;
			Vector3 movement = newtouchpos - ballpos;
			rb.AddForce (movement * speed);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}

	}
	void OnGUI (){
		content.text = "touchpos:" + (int)touchpos.x + "-" + (int)touchpos.y;
		GUI.Box (new Rect(10,10,180,20),content);
		content.text = "newballpos:" + (int)ballpos.x + "-" + (int)ballpos.y + "-" + (int)ballpos.z;
		GUI.Box (new Rect(10,40,180,20),content);
		content.text = "screen:" + (int)Screen.width + "-" + (int)Screen.height;
		GUI.Box (new Rect(10,70,180,20),content);
	}
}

using UnityEngine;
using System.Collections;

public class Observer : MonoBehaviour {
	private ArrayList ObiList = new ArrayList();


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddEventListener<Plaintiff>(Plaintiff a)
	{
		ObiList.Add(a);
	}

	public void NotifyEventOccur<Plaintiff,defendant>(Plaintiff a,defendant b)
	{

	}
}

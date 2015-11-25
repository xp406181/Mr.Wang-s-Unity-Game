using UnityEngine;
using System.Collections;

public class AsteRoidController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 SpawnValue;
	public float SpawnWait;

	public GUIText ScoreText;
	public GUIText RestartText;
	public GUIText GameOverText;

	private int m_Score;
	private bool m_GameOver;
	private bool m_Restart;

	// Use this for initialization
	void Start () {
		if(hazard == null)
		{
			return;
		}
		StartCoroutine(SpawnWaves());

		m_Score = 0;
		m_GameOver = false;
		m_Restart = false;
		GameOverText.text = "";
		RestartText.text = "";
		UpdateScore();
	}

	void Update()
	{
		if(m_Restart)
		{
			if(Input.GetKeyUp(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(SpawnWait);

		while(true)
		{
			float x = Random.Range(-SpawnValue.x,SpawnValue.x);
			Vector3 spawnPosition = new Vector3(x,SpawnValue.y,SpawnValue.z);
			Quaternion spawnRoatation = Quaternion.identity;
			Instantiate(hazard,spawnPosition,spawnRoatation);
			yield return new WaitForSeconds(SpawnWait);

			if(m_GameOver)
			{
				GameOverText.text = "Game Over!";
				RestartText.text = "Press 'R' to Restart";
				m_Restart = true;
			}
		}
	}

	public void AddScore(int score)
	{
		this.m_Score += score;
		UpdateScore();

	}

	private void UpdateScore()
	{
		ScoreText.text = "Score:" + this.m_Score;
	}

	public void GameOver()
	{
		m_GameOver = true;
	}
}

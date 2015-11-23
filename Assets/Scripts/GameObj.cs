using UnityEngine;
using System.Collections;


[System.Serializable]
public class Attr{
	public float MaxLife = 1.0f,CurLife = 1.0f,Attack = 1.0f,Defence = 0.0f;
}

public class GameObj : MonoBehaviour {
	public Attr Attr;
	private float m_MaxLife = 0.0f;
	private float m_Life = 0.0f;
	private float m_Attack = 0.0f;
	private float m_Defence = 0.0f;
	private bool m_LiveState = false;

	public float MaxLife
	{
		get
		{
			return m_MaxLife;
		}
		set
		{
			m_MaxLife = value;
		}
	}

	public float Life
	{
		get
		{
			return m_Life;
		}
		set
		{
			if(value <= 0)
			{
				LiveState = false;
			}
			else
			{
				LiveState = true;
			}

			if(value > m_MaxLife)
			{
				value = m_MaxLife;
			}

			m_Life = value;

		}
	}

	public float Attack
	{
		get
		{
			return m_Attack;
		}
		set
		{
			if(value < 0.0f)
			{
				value = 0.0f;
			}
			m_Attack = value;
		}
	}

	public float Defence
	{
		get
		{
			return m_Defence;
		}
		set
		{
			if(value < 0.0f)
			{
				value = 0.0f;
			}
			m_Defence = value;
		}
	}

	public bool LiveState
	{
		set
		{
			m_LiveState = value;
		}
		get
		{
			return m_LiveState;
		}
	}

	// Use this for initialization
	void Awake ()
	{
		InitObj(Attr);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	private void DecreaseLife(float damage)
	{
		Life = Life - damage;
	}

	private void IncreaseLife(float cure)
	{
		Life = Life + cure;
	}

	public void UnderAttack(float attack)
	{
		float damage = attack - Defence;
		DecreaseLife(damage);
	}

	public void UnderCure(float cure)
	{
		if(LiveState)
		{
			Life += cure;
		}
	}

	public void InitObj(float maxLife,float curLife,float attack,float defence)
	{
		MaxLife = maxLife;
		Life = curLife;
		Attack = attack;
		Defence = defence;
	}

	public void InitObj(Attr attr)
	{
		InitObj(attr.MaxLife,attr.CurLife,attr.Attack,attr.Defence);
	}
}

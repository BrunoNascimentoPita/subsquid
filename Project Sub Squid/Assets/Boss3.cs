using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    [SerializeField]
	int numberOfProjectiles;

	[SerializeField]
	GameObject projectile;

	Vector2 startPoint;

	float radius, moveSpeed;


	public float m_Velocidade;

	public Transform m_Posicao;

	public float m_TempoEspera;

	public float x_Min, x_Max, y_Min, y_Max;

	public float m_Tempo;

	// Use this for initialization
	void Start () 
	{
		radius = 5f;
		moveSpeed = 5f;
		StartCoroutine (SpawnProjectiles(numberOfProjectiles));

		m_Posicao.position = new Vector2(Random.Range(x_Min, x_Max), Random.Range(y_Min, y_Max));
		m_Tempo = m_TempoEspera;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetButtonDown ("Fire1")) {

			//StartCoroutine (SpawnProjectiles(numberOfProjectiles));
		}
			
			
		startPoint = transform.position;


		transform.position = Vector2.MoveTowards(transform.position, m_Posicao.position, m_Velocidade * Time.deltaTime);
		
		float _dist = Vector2.Distance(transform.position, m_Posicao.position);

		if (_dist <= .2f)
		{
			if (m_Tempo <= 0)
			{
				m_Posicao.position = new Vector2(Random.Range(x_Min, x_Max), Random.Range(y_Min, y_Max));
				m_Tempo = m_TempoEspera;
			}

			else
			m_Tempo -= Time.deltaTime;
			
		} 


	}

	IEnumerator SpawnProjectiles(int numberOfProjectiles)
	{
		float angleStep = 360f / numberOfProjectiles;
		float angle = 0f;

		for (int i = 0; i <= numberOfProjectiles - 1; i++) {
			
			float projectileDirXposition = startPoint.x + Mathf.Sin ((angle * Mathf.PI) / 180) * radius;
			float projectileDirYposition = startPoint.y + Mathf.Cos ((angle * Mathf.PI) / 180) * radius;

			Vector2 projectileVector = new Vector2 (projectileDirXposition, projectileDirYposition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			var proj = Instantiate (projectile, startPoint, Quaternion.identity);
			proj.GetComponent<Rigidbody> ().velocity = 
				new Vector2 (projectileMoveDirection.x, projectileMoveDirection.y);

			angle += angleStep;
		}

        yield return new WaitForSeconds (0.5f);

        //StartCoroutine (SpawnProjectiles(numberOfProjectiles));

	}

}

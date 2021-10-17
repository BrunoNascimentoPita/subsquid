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

	// Use this for initialization
	void Start () {
		radius = 5f;
		moveSpeed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			startPoint = transform.position;

			StartCoroutine (SpawnProjectiles(numberOfProjectiles));
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

        yield return new WaitForSeconds (0.2f);

        StartCoroutine (SpawnProjectiles(numberOfProjectiles));

	}

}

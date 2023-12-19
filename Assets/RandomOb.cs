using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
	public GameObject cucumberPrefab;
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(SpawnCucumber());
	}

	IEnumerator SpawnCucumber()
	{
		while (true)
		{
			float randomTime = Random.Range(1f, 3f);
			float randomPosition = Random.Range(-10f, 10f);

			yield return new WaitForSeconds(randomTime);
			Instantiate(cucumberPrefab, new Vector3(randomPosition, 10f, transform.position.x), Quaternion.identity);
		}
	}

}
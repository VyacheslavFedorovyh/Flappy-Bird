using UnityEngine;

public abstract class Generater : ObectPool
{
	[SerializeField] private GameObject _tempPlane;
	[SerializeField] private float _maxSpawnPositionY;
	[SerializeField] private float _minSpawnPositionY;

	private void Start()
	{
		Initialize(_tempPlane);
	}

	protected void Spawn(GameObject obect)
	{
		float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
		Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
		obect.SetActive(true);
		obect.transform.position = spawnPoint;

		DisableObjectAbroadScreen();
	}
}

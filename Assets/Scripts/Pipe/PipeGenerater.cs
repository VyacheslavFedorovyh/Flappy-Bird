using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerater : ObectPool
{
	[SerializeField] private GameObject _tempPlane;
	[SerializeField] private float _secondBetweenSpawn;
	[SerializeField] private float _maxSpawnPositionY;
	[SerializeField] private float _minSpawnPositionY;

	private float _elapsedTime = 0;

	private void Start()
	{
		Initialize(_tempPlane);
	}

	private void Update()
	{
		_elapsedTime += Time.deltaTime;

		if(_elapsedTime > _secondBetweenSpawn)
		{
			if(TryGetObject(out GameObject pipe))
			{
				_elapsedTime = 0;

				float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
				Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
				pipe.SetActive(true);
				pipe.transform.position = spawnPoint;

				DisableObjectAbroadScreen();
			}
		}
	}
}

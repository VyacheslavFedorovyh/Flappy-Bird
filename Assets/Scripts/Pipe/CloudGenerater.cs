using UnityEngine;

public class CloudGenerater : Generater
{
	[SerializeField] private float _maxSecondBetweenSpawn;
	[SerializeField] private float _minSecondBetweenSpawn;
	[SerializeField] private float _maxCloudScale;
	[SerializeField] private float _minCloudScale;

	private bool _nextSecondBetweenSpawn = true;
	private float _elapsedTime = 0;
	private float _secondBetweenSpawn;

	private void Update()
	{
		_elapsedTime += Time.deltaTime;

		if (_nextSecondBetweenSpawn)
			RandomSecondBetweenSpawn();

		if (_elapsedTime > _secondBetweenSpawn)
		{
			if (TryGetObject(out GameObject cloud))
			{
				_elapsedTime = 0;
				_nextSecondBetweenSpawn = true;
				cloud.transform.localScale = RandomCloudScale();
				Spawn(cloud);
			}
		}
	}

	private void RandomSecondBetweenSpawn()
	{
		_secondBetweenSpawn = Random.Range(_minSecondBetweenSpawn, _maxSecondBetweenSpawn);
		_nextSecondBetweenSpawn = false;
	}

	private Vector3 RandomCloudScale()
	{
		float result = Random.Range(_minCloudScale, _maxCloudScale);
		return new Vector3(result, result, result);
	}
}

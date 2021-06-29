using UnityEngine;

public class PipeGenerater : Generater
{
	[SerializeField] private float _secondBetweenSpawn;

	private float _elapsedTime = 0;

	private void Update()
	{
		_elapsedTime += Time.deltaTime;

		if (_elapsedTime > _secondBetweenSpawn)
		{
			if (TryGetObject(out GameObject pipe))
			{
				_elapsedTime = 0;
				Spawn(pipe);
			}
		}	
	}
}

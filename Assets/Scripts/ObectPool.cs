using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObectPool : MonoBehaviour
{
	[SerializeField] private int _capacity;
	[SerializeField] private GameObject _container;

	private Camera _camera;

	private List<GameObject> _pool = new List<GameObject>();

	protected void Initialize(GameObject prefab)
	{
		_camera = Camera.main;

		for (int i = 0; i < _capacity; i++)
		{
			GameObject spawned = Instantiate(prefab, _container.transform);
			spawned.SetActive(false);

			_pool.Add(spawned);
		}
	}

	protected bool TryGetObject(out GameObject result)
	{
		result = _pool.FirstOrDefault(p => p.activeSelf == false);

		return result != null;
	}

	protected void DisableObjectAbroadScreen()
	{
		Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f, _camera.transform.position.z));

		foreach (var item in _pool)
		{
			if (item.activeSelf == true)
				if (item.transform.position.x < disablePoint.x)				
					item.SetActive(false);				
		}
	}

	public void ResetPoll()
	{
		foreach (var item in _pool)
		{
			item.SetActive(false);
		}
	}
}

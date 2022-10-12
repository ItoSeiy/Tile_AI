using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCell : MonoBehaviour
{
	public bool Already => _enableEffect.activeInHierarchy;

	public bool ConnectSearch { get; set; }

	public GameObject EnableEffect => _enableEffect;

	[SerializeField]
	private List<PuzzleCell> _borderOnCells;

	[SerializeField]
	private GameObject _enableEffect;

	public void OnMouseDown()
	{
		if (_enableEffect.activeInHierarchy || PuzzleController.Instance.GuardClick)
		{
			return;
		}

		_enableEffect.SetActive(true);
		StartCoroutine(PuzzleController.Instance.StartSearchConnect());
		OnConnect();
	}

	public void OnConnect()
	{
		PuzzleController.Instance.AddConnect(this);

		foreach (var cell in _borderOnCells)
		{
			if (cell.Already && !PuzzleController.Instance.IsConnected(cell))
			{
				cell.OnConnect();
			}
		}
		ConnectSearch = false;
	}

	public void SetRelation(List<PuzzleCell> cells)
	{
		_borderOnCells = new List<PuzzleCell>();

		foreach (var cell in cells)
		{
			if (cell == this)
			{
				continue;
			}

			float distance = Vector3.Distance(cell.transform.position, this.transform.position);
			if (distance < 1.1f)
			{
				_borderOnCells.Add(cell);
			}
		}

		_enableEffect = transform.Find("Plane").gameObject;
	}
}

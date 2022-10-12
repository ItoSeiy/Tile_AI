using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : SingletonMonoBehaviour<PuzzleController>
{
	public List<PuzzleCell> _connectCells { get; private set; } = new List<PuzzleCell>();

	[SerializeField]
	private GameObject _deleteText;

	public bool GuardClick { get; private set; }

	public void AddConnect(PuzzleCell cell)
	{
		_connectCells.Add(cell);
		cell.ConnectSearch = true;
	}

	public bool IsConnected(PuzzleCell cell)
	{
		return _connectCells.Contains(cell);
	}

	public IEnumerator StartSearchConnect()
	{
		GuardClick = true;

		_connectCells.Clear();
		yield return null;
		if (_connectCells.Count >= 4)
		{
			yield return StartCoroutine(Delete());
		}

		GuardClick = false;
	}

	private IEnumerator Delete()
	{
		_deleteText.SetActive(true);

		yield return new WaitForSeconds(0.1f);
		foreach (var cell in _connectCells)
		{
			yield return new WaitForSeconds(0.1f);
			cell.EnableEffect.SetActive(false);
		}

		yield return new WaitForSeconds(1f);
		_connectCells.Clear();
		_deleteText.SetActive(false);
	}
}

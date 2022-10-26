using System.Collections.Generic;
using UnityEngine;


public class TileCell : MonoBehaviour
{
	[SerializeField]
	private List<TileCell> _borderOnTiles;

	[SerializeField] 
	private TextMesh _number;

	[SerializeField] 
	private GameObject _enableEffect;

	private readonly int NEED_STEP = 1;
	private int _nowStep = -1;

	public void OnMouseDown()
	{
		if (!_enableEffect.activeInHierarchy)
		{
			return;
		}

		UnitMoveController.Instance.MoveToUnit(this);
	}

	public virtual void SetStep(int count)
	{
		if (count < 0 || _nowStep > count)
		{
			return;
		}

		_number.text = count.ToString();
		_nowStep = count;

		_enableEffect.SetActive(true);

		foreach (var tile in _borderOnTiles)
		{
			var nextStepCount = count - tile.NEED_STEP;
			tile.SetStep(nextStepCount);
		}
	}

	public void SetRelation(List<TileCell> cells)
	{
		_borderOnTiles.Clear();
		foreach (var cell in cells)
		{
			if (cell == this)
			{
				continue;
			}

			float distance = Vector3.Distance(cell.transform.position, this.transform.position);
			if (distance < 1.1f)
			{
				_borderOnTiles.Add(cell);
			}
		}
	}

	public void MoveEnd()
	{
		_enableEffect.SetActive(false);
		_number.text = string.Empty;
		_nowStep = -1;
	}
}

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

	private int needStep = 1;
	private int nowStep = -1;

	public virtual void SetStep(int count)
	{
		if (count < 0 || nowStep > count)
		{
			return;
		}

		_number.text = count.ToString();
		nowStep = count;

		_enableEffect.SetActive(true);

		foreach (var tile in _borderOnTiles)
		{
			var nextStepCount = count - tile.needStep;
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

	public void OnMouseDown()
	{
		if (!_enableEffect.activeInHierarchy)
		{
			return;
		}

		UnitMoveController.Instance.MoveToUnit(this);
	}

	public void MoveEnd()
	{
		_enableEffect.SetActive(false);
		_number.text = string.Empty;
		nowStep = -1;
	}
}

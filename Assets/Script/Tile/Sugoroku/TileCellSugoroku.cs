using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileRelation
{
	public TileCellSugoroku ToTile { get; private set; }
	public bool Movable { get; private set; }

	public TileRelation(TileCellSugoroku tile)
	{
		ToTile = tile;
	}

}

public class TileCellSugoroku : MonoBehaviour
{
	[SerializeField] private List<TileRelation> relations = new List<TileRelation>();

	[SerializeField]
	private TextMesh number;

	[SerializeField]
	private GameObject enableEffect;

	private int needStep = 1;
	private int nowStep = -1;

	public void OnMouseDown()
	{
		if (!enableEffect.activeInHierarchy)
		{
			return;
		}

		UnitMoveController.Instance.MoveToUnit(this);
	}


	private bool IsMovable(TileCellSugoroku toTile)
	{
		foreach (var relation in relations)
		{
			if (relation.ToTile == toTile)
			{
				return relation.Movable;
			}
		}

		return false;
	}

	public void SetStep(int count)
	{
		if (count < 0 || nowStep > count)
		{
			return;
		}

		if (number)
		{
			number.text = count.ToString();
		}

		nowStep = count;

		if (nowStep == 0)
		{
			enableEffect.SetActive(true);
		}

		foreach (var relation in relations)
		{
			if (IsMovable(relation.ToTile))
			{
				var nextStepCount = count - relation.ToTile.needStep;
				relation.ToTile.SetStep(nextStepCount);
			}
		}
	}

	public void SetRelation(List<TileCellSugoroku> cells)
	{
		relations = new List<TileRelation>();

		foreach (var cell in cells)
		{
			if (cell == this)
			{
				continue;
			}

			float distance = Vector3.Distance(cell.transform.position, this.transform.position);
			if (distance < 1.1f)
			{
				relations.Add(new TileRelation(cell));
			}
		}

		enableEffect = transform.Find("Plane").gameObject;
		number = GetComponentInChildren<TextMesh>();
	}

	public void MoveEnd()
	{
		enableEffect.SetActive(false);
		nowStep = -1;
	}
}


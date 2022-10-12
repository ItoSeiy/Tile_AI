
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileSugorokuSetting : MonoBehaviour
{
	[ContextMenu("AddTileCell")]
	public void AddTileCell()
	{
		var mastGameObject = GetComponentsInChildren<Transform>().Select(t => t.gameObject);

		foreach (Transform child in transform)
		{
			if (!child.GetComponent<TileCellSugoroku>())
			{
				child.gameObject.AddComponent<TileCellSugoroku>();
			}
		}
	}

	[ContextMenu("Remove")]
	public void RemoveTileCell()
	{
		foreach (Transform child in transform)
		{
			if (child.GetComponent<TileCellSugoroku>())
			{
				DestroyImmediate(child.gameObject.GetComponent<TileCellSugoroku>());
			}
		}
	}

	[ContextMenu("SetRelationCell")]
	public void TileCellSetRelations()
	{
		var cells = GetComponentsInChildren<TileCellSugoroku>();
		foreach (var cell in cells)
		{
			cell.SetRelation(cells.ToList());
		}
	}
}

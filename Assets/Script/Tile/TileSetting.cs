
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileSetting : MonoBehaviour
{
    private void Awake()
    {
		TileCellSetRelations();	
    }

    [ContextMenu("AddTileCell")]
	public void AddTileCell()
	{
		var mastGameObject = GetComponentsInChildren<Transform>().Select(t => t.gameObject);

		foreach (Transform child in transform)
		{
			if (!child.GetComponent<TileCell>())
			{
				child.gameObject.AddComponent<TileCell>();
			}
		}
	}

	[ContextMenu("Remove")]
	public void RemoveTileCell()
	{
		foreach (Transform child in transform)
		{
			if (child.GetComponent<TileCell>())
			{
				DestroyImmediate(child.gameObject.GetComponent<TileCell>());
			}
		}
	}

	[ContextMenu("SetRelationCell")]
	public void TileCellSetRelations()
	{
		var cells = GetComponentsInChildren<TileCell>();
		foreach (var cell in cells)
		{
			cell.SetRelation(cells.ToList());
		}
	}

}

using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
	[SerializeField]
	private TileCell _nowPositionTile;

	[SerializeField]
	private TileCellSugoroku _nowPositionTileSugoroku;

	[SerializeField]
	private int _stepValue;

	public void SetMoveTile(TileCell tile)
	{
		_nowPositionTile = tile;
		transform.position = new Vector3(_nowPositionTile.transform.position.x,
											  transform.position.y,
											  _nowPositionTile.transform.position.z);
	}

	public void SetMoveTile(TileCellSugoroku tile)
	{
		_nowPositionTileSugoroku = tile;
		transform.position = new Vector3(_nowPositionTileSugoroku.transform.position.x,
										 transform.position.y,
										 _nowPositionTileSugoroku.transform.position.z);
	}

	public void OnMouseDown()
	{
		if (_nowPositionTile)
		{
			_nowPositionTile.SetStep(_stepValue);
		}

		if (_nowPositionTileSugoroku)
		{
			_nowPositionTileSugoroku.SetStep(_stepValue);
		}

		UnitMoveController.Instance.SetMoveUnit(this);
	}
}

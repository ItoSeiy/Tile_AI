using System;

public class UnitMoveController : SingletonMonoBehaviour<UnitMoveController>
{
	private UnitBase _unitItendedToMove;
	private TileCell[] _allTiles;
	private TileCellSugoroku[] _allSugorokuTiles;

	private void Awake()
	{
		_allTiles = GetComponentsInChildren<TileCell>();
		_allSugorokuTiles = GetComponentsInChildren<TileCellSugoroku>();
	}

	public void SetMoveUnit(UnitBase target)
	{
		_unitItendedToMove = target;
	}

	public void MoveToUnit(TileCell moveToTile)
	{
		foreach (var tile in _allTiles)
		{
			tile.MoveEnd();
		}

		_unitItendedToMove.SetMoveTile(moveToTile);
	}

	public void MoveToUnit(TileCellSugoroku moveToTile)
	{
		_unitItendedToMove.SetMoveTile(moveToTile);

		foreach (var tile in _allSugorokuTiles)
		{
			tile.MoveEnd();
		}
	}
}

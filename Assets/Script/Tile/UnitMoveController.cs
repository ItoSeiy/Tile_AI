public class UnitMoveController : SingletonMonoBehaviour<UnitMoveController>
{
	private PlayerUnit _unitItendedToMove;
	private TileCell[] _allTiles;
	private TileCellSugoroku[] _allSugorokuTiles;

	private void Awake()
	{
		_allTiles = GetComponentsInChildren<TileCell>();
		_allSugorokuTiles = GetComponentsInChildren<TileCellSugoroku>();
	}

	public void SetMoveUnit(PlayerUnit target)
	{
		_unitItendedToMove = target;
	}

	public void MoveToUnit(TileCell moveToTile)
	{
		_unitItendedToMove.SetMoveTile(moveToTile);

		foreach (var tile in _allTiles)
		{
			tile.MoveEnd();
		}
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

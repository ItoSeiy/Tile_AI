public class PlayerUnit : UnitBase
{
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

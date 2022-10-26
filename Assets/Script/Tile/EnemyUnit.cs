public class EnemyUnit : UnitBase
{
    public void SetStep()
    {
		if (!_moveAble) return;

		if (_nowPositionTile)
		{
			_nowPositionTile.SetStep(_stepValue);
		}

		UnitMoveController.Instance.SetMoveUnit(this);
    }
}

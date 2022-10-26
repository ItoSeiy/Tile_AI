using UnityEngine;
using System;

public abstract class UnitBase : MonoBehaviour
{
	public bool MoveAble => _moveAble;

	public event Action OnMoveEnd;

	[SerializeField]
	protected TileCell _nowPositionTile;

	[SerializeField]
	protected TileCellSugoroku _nowPositionTileSugoroku;

	[SerializeField]
	protected int _stepValue;

	protected bool _moveAble = false;

    public virtual void SetMoveTile(TileCell tile)
    {
		_nowPositionTile = tile;
		transform.position = new Vector3(_nowPositionTile.transform.position.x,
										 transform.position.y,
										 _nowPositionTile.transform.position.z);

		OnMoveEnd?.Invoke();
	}

    public virtual void SetMoveTile(TileCellSugoroku tile)
    {

		_nowPositionTileSugoroku = tile;
		transform.position = new Vector3(_nowPositionTileSugoroku.transform.position.x,
										 transform.position.y,
										 _nowPositionTileSugoroku.transform.position.z);
	}

	public void SetMoveAble(bool active)
    {
		_moveAble = active;
    }
}

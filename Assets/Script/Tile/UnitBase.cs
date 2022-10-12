using UnityEngine;

public abstract class UnitBase : MonoBehaviour
{
	[SerializeField]
	protected TileCell _nowPositionTile;

	[SerializeField]
	protected TileCellSugoroku _nowPositionTileSugoroku;

	[SerializeField]
	protected int _stepValue;

	public virtual void SetMoveTile(TileCell tile)
    {
		_nowPositionTile = tile;
		transform.position = new Vector3(_nowPositionTile.transform.position.x,
											  transform.position.y,
											  _nowPositionTile.transform.position.z);
	}

    public virtual void SetMoveTile(TileCellSugoroku tile)
    {

		_nowPositionTileSugoroku = tile;
		transform.position = new Vector3(_nowPositionTileSugoroku.transform.position.x,
										 transform.position.y,
										 _nowPositionTileSugoroku.transform.position.z);
	}
}

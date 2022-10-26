using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private Button _playerTurnFinish;

    [SerializeField]
    private List<PlayerUnit> _playerUnits = new List<PlayerUnit>();

    [SerializeField]
    private List<EnemyUnit> _enemyUnits = new List<EnemyUnit>();

    private Trun _currentTurn;

    private void Start()
    {
        SetEvents();
        LotteryTurn();
    }

    private void SetEvents()
    {
        _playerUnits.ForEach(x =>
        {
            x.OnMoveEnd += () =>
            {
                x.SetMoveAble(false);
                CheckTrunFinish();
            };
        });

        _enemyUnits.ForEach(x =>
        {
            x.OnMoveEnd += () =>
            {
                x.SetMoveAble(false);
                CheckTrunFinish();
            };
        });

        _playerTurnFinish.onClick.AddListener(SetEnemyTurn);
    }

    private void LotteryTurn()
    {
        int result = Random.Range(0, 2);

        if (result == 0)
        {
            SetPlayerTrun();
            _currentTurn = Trun.Player;
            print($"ターンの抽選の結果は{result} Player");
        }
        else
        {
            SetEnemyTurn();
            _currentTurn = Trun.Enemy;
            print($"ターンの抽選の結果は{result} Enemy");
        }
    }

    private void SetPlayerTrun()
    {
        _playerUnits.ForEach(x => x.SetMoveAble(true));

        _enemyUnits.ForEach(x => x.SetMoveAble(false));

        _playerTurnFinish.interactable = true;
    }

    private void SetEnemyTurn()
    {
        _enemyUnits.ForEach(x => x.SetMoveAble(true));

        _playerUnits.ForEach(x => x.SetMoveAble(false));

        _playerTurnFinish.interactable= false;
    }

    private void CheckTrunFinish()
    {
        if(_currentTurn == Trun.Player && _playerUnits.All(x => !x.MoveAble))
        {
            SetEnemyTurn();
        }
        else if(_currentTurn == Trun.Enemy && _enemyUnits.All(x => !x.MoveAble))
        {
            SetPlayerTrun();
        }
    }
}

public enum Trun { Player, Enemy}
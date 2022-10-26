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

    private EnemyUnit _currentEnemyUnit = null;

    private int _currentEnemyIndex;

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
                if(!CheckTrunFinish())
                    IncrementEnemyTurn();
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
            print($"ターンの抽選の結果は{result} Player");
        }
        else
        {
            SetEnemyTurn();
            print($"ターンの抽選の結果は{result} Enemy");
        }
    }

    private void SetPlayerTrun()
    {
        Init();

        _currentTurn = Trun.Player;
        print($"ターンが{_currentTurn}になった");

        _playerUnits.ForEach(x => x.SetMoveAble(true));

        _playerTurnFinish.interactable = true;
    }

    private void SetEnemyTurn()
    {
        Init();

        _currentTurn = Trun.Enemy;
        print($"ターンが{_currentTurn}になった");

        _enemyUnits.ForEach(x => x.SetMoveAble(true));

        IncrementEnemyTurn();

        _playerTurnFinish.interactable = false;
    }

    private bool CheckTrunFinish()
    {
        if(_currentTurn == Trun.Player && _playerUnits.All(x => !x.MoveAble))
        {
            SetEnemyTurn();
            return true;
        }
        else if(_currentTurn == Trun.Enemy && _enemyUnits.All(x => !x.MoveAble))
        {
            SetPlayerTrun();
            return true;
        }

        return false;
    }

    private void IncrementEnemyTurn()
    {
        _currentEnemyIndex++;
        print(_currentEnemyIndex);
        _currentEnemyUnit = _enemyUnits[_currentEnemyIndex];
        print($"現在の敵のUnitは{_currentEnemyUnit.gameObject.name}");

        new EnemyAI(_currentEnemyUnit);
    }

    private void Init()
    {
        print("Init");
        _playerUnits.ForEach(x => x.SetMoveAble(false));
        _enemyUnits.ForEach(x => x.SetMoveAble(false));

        _currentEnemyUnit = null;
        _currentEnemyIndex = -1;
    }
}

public enum Trun { Player, Enemy}
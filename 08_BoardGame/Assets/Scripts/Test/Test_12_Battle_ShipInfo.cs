using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_12_Battle_ShipInfo : TestBase
{
    UserPlayer user;
    EnemyPlayer enemy;

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;

        user = gameManager.UserPlayer;
        enemy = gameManager.EnemyPlayer;

        user.AutoShipDeployment(true);
        enemy.AutoShipDeployment(true);

        gameManager.GameState = GameState.Battle;
        user.BindInputFuncs();

        gameManager.TurnController.onTurnStart += (_) => user.AutoAttack();
        user.AutoAttack();
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        enemy.AutoAttack();
    }

    protected override void OnTestRClick(InputAction.CallbackContext context)
    {
        Vector2Int grid = user.Board.GetMouseGridPosition();
        enemy.Attack(grid);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_GameOver : TestBase
{
    public int score;
    public RankLine line;
    Player player;
    public RankPanel panel;

    private void Start()
    {
        player = GameManager.Instance.Player;
    }
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        player.Test_Die();
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        player.Test_SetScore(score);
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        line.SetData("가가가", 100);
    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
        panel.Test_DefaultRankPanel();
    }
    protected override void OnTest5(InputAction.CallbackContext context)
    {
        panel.Test_SaveRankPanel();
    }
}

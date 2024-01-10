using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : Singleton<GamaManager>
{
    Player player;

    public Player Player
    {
        get
        {
            if(player == null)  //초기화 전에 Player에 접근했을 경우
            {
                OnInitailize();
            }
            return player;
        }
    }
    protected override void OnInitailize()
    {
        base.OnInitailize();
        player = FindAnyObjectByType<Player>();
    }
}

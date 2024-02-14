using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    Player player;
    public Player Player
    {
        get
        {
            if(player == null)
                player = FindAnyObjectByType<Player>();
            return player;
        }
    }

    VirtualStick stick;
    public VirtualStick Stick
    {
        get
        {
            if (stick == null)
            {
                stick = FindAnyObjectByType<VirtualStick>();
            }
            return stick;
        }

    }
    VitrualButton button;

    public VitrualButton Button
    {
        get
        {
            if(button == null)
            {
                button = FindAnyObjectByType<VitrualButton>();
            }
            return button;
        }
    }
    protected override void OnInitialize()
    {
        player = FindAnyObjectByType<Player>();
    }
}

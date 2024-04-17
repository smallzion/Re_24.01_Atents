using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearPanel : MonoBehaviour
{
    private void Awake()
    {
        transform.gameObject.SetActive(false);
    }
}

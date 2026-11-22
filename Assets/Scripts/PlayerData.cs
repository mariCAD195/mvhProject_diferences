using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int playerPoints;
    public static PlayerData Instance {get; private set;}

    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}

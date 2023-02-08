using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;

    [SerializeField] private int MaxPlayers = 2;

    public static PlayerConfigurationManager Instance { get; private set; }

   private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Creating instance"); 
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);

            playerConfigs = new List<PlayerConfiguration>();
        }
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }

    public PlayerInput Input { get; set; }

    public int PlayerIndex { get; set; }

    public bool isReady { get; set; }
}
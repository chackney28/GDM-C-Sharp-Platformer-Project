using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Sets it as a manager
    public static GameManager Instance { get; private set; }

    //Various checks for when thigns happen
    public event Action<int> scoreChange;
    public event Action<int> hpChange;
    public event Action gamedOver;
    
    //Variables for the player
    public int playerHp = 100;
    public int playerScore = 0;

    //Sets it as manager 2
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        
        // Persist this GameObject across all scenes
        DontDestroyOnLoad(gameObject);
    }
    
    //A function to change the points within the manager
    public void changePoints(int points){
        //A: I use print because my unity yells at me for using Debug.Log()
        //B: These are here to check if they are triggering
        //print("Coin");
        playerScore += points;
        scoreChange?.Invoke(playerScore);
    }

    //A function used to change the hp within the manager
    public void changeHp(int hit){
        //print("Hit");
        playerHp += hit;
        if (playerHp <= 0){
            playerHp = 0;
            gamedOver?.Invoke();
        }
        hpChange?.Invoke(playerHp);
    }
}
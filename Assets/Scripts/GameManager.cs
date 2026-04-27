using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public float timer;
    
    public bool switchPlayers = false;

    public Transform player1;
    public Transform player1Goal;
    
    public Transform player2;
    public Transform player2Goal;

    public Transform ball;

    public TMPro.TextMeshProUGUI timerText;

    public int player1Score = 0;
    public int player2Score = 0;

    public TMPro.TextMeshProUGUI player1ScoreText;
    public TMPro.TextMeshProUGUI player2ScoreText;
    
    public AudioSource audioSource;
    public AudioClip countDown;

    public int starterTimer = 15;

    private void Awake()
    {
        Instance = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1 = GameObject.Find("Player 1").GetComponent<Transform>();
        player2 = GameObject.Find("Player 2").GetComponent<Transform>();
        
        ball = GameObject.Find("Ball").GetComponent<Transform>();
        
        player1Goal = GameObject.Find("Player 1 Goal").GetComponent<Transform>();
        player2Goal = GameObject.Find("Player 2 Goal").GetComponent<Transform>();
        

        timerText.text = Mathf.RoundToInt(timer).ToString();
    }

    public void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;

        player1ScoreText.text = "Player 1: " + player1Score;
        player2ScoreText.text = "Player 2: " + player2Score;
        
        timer = starterTimer;
        timerText.text = Mathf.RoundToInt(timer).ToString();
        
        switchPlayers = false;

        ball.transform.position = new Vector3(0, 0, 0);
        player1.transform.position = new Vector3(-15, 0, 0);
        player2.transform.position = new Vector3(15, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        timerText.text = Mathf.RoundToInt(timer).ToString();
        
        Debug.Log(timer);

       

        if (timer <= 0)
        {
            
            audioSource.PlayOneShot(countDown);
            timer += 15;
            
            Vector2 tempPlayer1 = player1.position;
            Vector2 tempPlayer1Goal = player1Goal.position;
            
            player1.position = player2.position;
            player1Goal.position = player2Goal.position;
            
            player2.position = tempPlayer1;
            player2Goal.position = tempPlayer1Goal;
            
            switchPlayers = true;
            
            Debug.Log("Switched Players");
        }
        else
        {
            switchPlayers = false;
        }
    }
    
    public void AddPlayer1Score()
    {
        player1Score++;
        player1ScoreText.text = "Player 1: " + player1Score;
    }

    public void AddPlayer2Score()
    {
        player2Score++;
        player2ScoreText.text = "Player 2: " + player2Score;
    }
}

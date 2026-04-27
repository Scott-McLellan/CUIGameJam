using System;
using UnityEngine;

public class PlayerTwoGoal : MonoBehaviour
{
    
    public TMPro.TextMeshProUGUI player1GoalText;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.AddPlayer1Score();
        }
    }
}

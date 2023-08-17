using System;
using QuizModule;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
   
    private Quiz quiz;
    private EndScreen endScreen;

  
    private void Start()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
        
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (quiz.isCompleted)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.CalculateFinalScore();
        }
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
  
}
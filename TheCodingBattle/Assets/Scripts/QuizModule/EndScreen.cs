using System;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI levelEndText;
   private ScoreManager m_ScoreManager;

   private void Start()
   {
      m_ScoreManager = FindObjectOfType<ScoreManager>();
   }

   public void CalculateFinalScore()
   {
      levelEndText.text = "Your Score: " + m_ScoreManager.CalculateScore();
   }
}

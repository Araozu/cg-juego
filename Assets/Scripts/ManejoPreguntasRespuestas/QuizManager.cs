using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
  
   public LoadQuestionAndAnswerData data;
   public List<QuestionAndAnswer> qAs;
   public GameObject[]options;
   public int currentQuestion;
   
   public TMP_Text QuestionTxt;
   public TMP_Text scoreTxt;
   
   public GameObject Quizpanel;
   public GameObject GoPanel;
   
   int totalQuestions=0;
   public int score;
   
   private void Start(){
        data=new LoadQuestionAndAnswerData();
   	data.LoadQuestionAndAnswer();
   	qAs=data.questionAndAnswerDatabase;
   	totalQuestions=qAs.Count;
   	GoPanel.SetActive(false);
   	generateQuestion();
   
   }
   
 
   
   void GameOver(){
   Quizpanel.SetActive(false);
   GoPanel.SetActive(true);
   scoreTxt.text=score+"/"+totalQuestions;
   }
   
   public void correct(){
  	
  	score+=1;
   	qAs.RemoveAt(currentQuestion);
   	generateQuestion();
   }
   
   public void wrong(){
    //when you answer wrong 
   qAs.RemoveAt(currentQuestion);
   generateQuestion();
   }
   
   
   public void SetAnswer(){
   for(int i=0;i<options.Length;i++){
   options[i].GetComponent<Answer>().isCorrect=false; 
   options[i].transform.GetChild(0).GetComponent<TMP_Text>().text=qAs[currentQuestion].Answers[i];
   if(qAs[currentQuestion].CorrectAnswer==i+1){
   options[i].GetComponent<Answer>().isCorrect=true;
   }
   }
   }
   
   public void generateQuestion(){
   if(qAs.Count>0){
   currentQuestion=Random.Range(0,qAs.Count);
   QuestionTxt.text=qAs[currentQuestion].Question;
   SetAnswer();
   }else {
   Debug.Log("Out ot questions");
   GameOver();
   }
   }
}

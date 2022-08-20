using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadQuestionAndAnswerData : MonoBehaviour
{
	
	public QuestionAndAnswer blankQuestionAndAnswer;	
	public List<QuestionAndAnswer> questionAndAnswerDatabase=new List<QuestionAndAnswer>();
   
    
    public void LoadQuestionAndAnswer(){
    	//Clear database
    	questionAndAnswerDatabase.Clear();
    	
    	//Read CSV files
    	List<Dictionary<string,object>> data=CSVReader.Read("QuestionAndAnswerDatabase");
    	for(var i=0;i<data.Count;i++){
    	string [] Answers=new string[4];
    	string question=data[i]["Question"].ToString();
    	Answers[0]=data[i]["Option1"].ToString();
    	Answers[1]=data[i]["Option2"].ToString();
    	Answers[2]=data[i]["Option3"].ToString();
    	Answers[3]=data[i]["Option4"].ToString();
    	int correctAnswer=int.Parse(data[i]["CorrectAnswer"].ToString(),System.Globalization.NumberStyles.Integer);
    	int level=int.Parse(data[i]["level"].ToString(),System.Globalization.NumberStyles.Integer);
    	
    	AddQuestionAndAnswer(question,Answers,correctAnswer,level);
    	}
    }
    
    void AddQuestionAndAnswer(string Question,string [] Answers,int CorrectAnswer,int level){
    
     QuestionAndAnswer qAs=new QuestionAndAnswer(Question,Answers,CorrectAnswer, level);
     questionAndAnswerDatabase.Add(qAs);
    Debug.Log("Se sustrajo correctamente "+Question+" - "+Answers+" - "+CorrectAnswer+" - "+ level);
    
    }
   
}

[System.Serializable]
public class QuestionAndAnswer
{
   public string Question;
   public string [] Answers;
   public int CorrectAnswer;
   public int level;
   
   public  QuestionAndAnswer(string Q,string [] Ans,int CAn,int l){
   	Question=Q;
   	Answers=Ans;
   	CorrectAnswer=CAn;
   	level=l;
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnswer : MonoBehaviour
{
    public GameObject options;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision  other){
    
    Vector3 position = new Vector3(-0.989f, 2.0f, -0.824f);
   
    
        if (other.gameObject.tag == "opt1")
 	 {
 	 	Debug.Log("op1");
 	 	options.transform.GetChild(1).GetComponent<Answer>().AnswerQuestion();
 	 	transform.position = position;
 	 	
    		
    		
    	
  	}
  	 if (other.gameObject.tag == "opt2")
 	 {	
 	 	Debug.Log("op2");
 	 	options.transform.GetChild(2).GetComponent<Answer>().AnswerQuestion();
 	 	transform.position = position;
    		
    		
    		
  	}
  	 if (other.gameObject.tag == "opt3")
 	 {
    		Debug.Log("op3");
    		options.transform.GetChild(3).GetComponent<Answer>().AnswerQuestion();
    		
    		
    		
  	}
  	 if (other.gameObject.tag == "opt4")
 	 {
    		Debug.Log("op4");
    		options.transform.GetChild(4).GetComponent<Answer>().AnswerQuestion();
    		
    		
    		
  	}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
   public void exit()
   {
      print("clicked");   
      UnityEditor.EditorApplication.isPlaying = false;//used when playing in the unity editor 
      Application.Quit();//used when playing a built game    
   }
}

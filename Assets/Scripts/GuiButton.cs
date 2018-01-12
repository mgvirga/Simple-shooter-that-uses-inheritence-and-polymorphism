using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;

public class GuiButton : MonoBehaviour
{
    
   
  
    public void GoToLevel(string level)
    {
        SceneManager.LoadScene(level);          // easiest scene transition script ever
    }
   
    }

  


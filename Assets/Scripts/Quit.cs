using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {





    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
          
            Application.Quit();
        }

    }
}

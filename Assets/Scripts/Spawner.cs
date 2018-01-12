using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Spawner : MonoBehaviour                // Jonathan Depina and Matthew Virga 
{
    private List<int> usedNum = new List<int>();
    public List<Transform> weapons = new List<Transform>();
    Vector3 wPos;
    public GameObject player;
    StreamReader sr;
    Vector3 pos;
    int timer = 400;
    public Transform[] spawn = new Transform[4];
    public GameObject[] enemi = new GameObject[3];
    
    // Use this for initialization
    void Start()
    {
        Spawn();
        PlayerSpawn("PlayerSpawn.txt");                 // This is how we spawn in our players and weapons they are read from 2 seperate files. The methods are ran with the file names as parameters
        WeaponSpawn("WeaponsSpawn.txt");
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        Spawn();
    }
    
    public void Spawn()
    {
        if (timer == 0)
        {
            int tele_num = Random.Range(0, 3);
            int enemi_num = Random.Range(0, 3);
            Instantiate(enemi[enemi_num], spawn[tele_num].position, spawn[tele_num].rotation);      // Randomly spawn enemies
            timer = 400;
        }
    }
    void PlayerSpawn(string name)
    {
        try
        {
           StreamReader sr = new StreamReader(Application.dataPath + "/" + name);           // Spawn in player
            string dataline = "";
            dataline = sr.ReadLine();
            while (dataline != null)
            {
                Debug.Log(dataline);

                string[] values = dataline.Split(',');
                pos.x = float.Parse(values[1]);
                pos.y = float.Parse(values[2]);
                pos.z = float.Parse(values[3]);

                player = (GameObject)Instantiate(player);
                player.transform.position = pos;
                dataline = sr.ReadLine();
            }

        }
        catch (IOException e)
        {
            Debug.Log(e.Message);
        }
      
        finally
        {
            if (sr != null)
                sr.Close();
        }
    }
    void WeaponSpawn(string name)
    {
        
        try
        {
            sr = new StreamReader(Application.dataPath + "/" + name);                       
            string dataline = "";
            dataline = sr.ReadLine();
            while (dataline != null)
            {

               
                
                string[] wspawns = dataline.Split(',');

                
                wPos.x = float.Parse(wspawns[0]);
                wPos.y = float.Parse(wspawns[1]);
                wPos.z = float.Parse(wspawns[2]);
                

                GameObject weapon = (GameObject)Instantiate(weapons[UniqueInt(0,3)].gameObject);            //This randomly spawns in weapons through 3 different positions
                    weapon.transform.position = wPos;
                
                    dataline = sr.ReadLine();
                



            }
            
                
            
            

        }
   
   
        catch (IOException e)
        {
            Debug.Log(e.Message);
        }
        
        finally
        {
            if (sr != null)
                sr.Close();
        }

    }
    public int UniqueInt(int min, int max)          // I had to make this to ensure that the same random number would not be used twice when spawning weapons
    {
        int num = Random.Range(min, max);

        if (usedNum.Contains(num))
        {
            usedNum.Add(num);
            return UniqueInt(min, max);
        }
        else
            usedNum.Add(num);
            return num;
    }
}


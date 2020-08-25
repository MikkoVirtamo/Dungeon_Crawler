using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    private GameObject[] treasureSpawns;
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    //public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;
    public static int numRooms = 0;
    //testing
    [SerializeField]
    private int maxRoomsVisible = 15;
    public static int maxRooms = 15;
    // Start is called before the first frame update

    private void Start()
    {
        maxRooms = maxRoomsVisible;
    }
    // Update is called once per frame
    void Update()
    {
        // The boss room trigger is spawned into the last room after 
        // a certain amount of time has passed to ensure all rooms have spawned
        if(waitTime <= 0 && !spawnedBoss)
        {
            //Debug.Log("the number of rooms is " + numRooms);
            Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            spawnedBoss = true;
            treasureSpawns = GameObject.FindGameObjectsWithTag("treasureSpawner");
            //Debug.Log(treasureSpawns.Length);


            // I moved all the below code into their own methods, but I kept them here 
            // because I like looking at it

            /* if (treasureSpawns.Length == 0)
             {
                 //do something if no treasure rooms spawn somehow, which shouldn't happen anyway
             }
             else if(treasureSpawns.Length == 1)
             {
                 SpawnSomeTreasure();
                 //SpawnAllTreasure();
                 Debug.Log(treasureSpawns[0].transform.parent.name);
                 //have to make sure the only treasure spawn isn't the boss room somehow
             }
             else if(treasureSpawns.Length == 2)
             {
                 //SpawnSomeTreasure();
                 SpawnAllTreasure();
                 Debug.Log(treasureSpawns[0].transform.parent.name);
                 Debug.Log(treasureSpawns[1].transform.parent.name);
                 //have to make sure the second one isn't the boss room somehow
             }
             else if(treasureSpawns.Length == 3)
             {
                 //SpawnSomeTreasure();
                 SpawnAllTreasure();
                 //spawn treasure in the first two rooms
             }
             else if(treasureSpawns.Length >= 4)
             {
                 //SpawnSomeTreasure();
                 SpawnAllTreasure();
                 //check for total number of rooms
                 //decide how many treasure to spawn
             }*/
            //SpawnAllTreasure();


            //spawn treasure in various rooms
            SpawnSomeTreasure();
            Debug.Log(treasureSpawns[treasureSpawns.Length - 1].transform.parent.position);
            Debug.Log(rooms[rooms.Count - 1].transform.position);
            CheckBossRoom();       
            
        }else
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void CheckBossRoom()
    {
        //I was originally planning on including a key for the boss room in the last spawned treasure chest
        //and this was supposed to check if the key would have ended up being locked in the room the key was needed for
        if(treasureSpawns[treasureSpawns.Length-1].transform.parent.position == rooms[rooms.Count - 1].transform.position)
        {
            //Debug.Log("The last treasure is in the same room as the boss");
        }
    }

    /*
     //This was for possibly putting treasure in every room, but I decided against it at the time
    private void SpawnAllTreasure()
    {
        for(int i = 0; i<treasureSpawns.Length; i++)
        {
            treasureSpawns[i].GetComponent<spawnTreasure>().SpawnTreasureChest();
        }
    }*/

        //Places treasure in various rooms depending on how many rooms were spawned
    private void SpawnSomeTreasure()
    {
        if(numRooms >=4 && numRooms < 6)
        {
            treasureSpawns[0].GetComponent<spawnTreasure>().SpawnTreasureChest();
        }
        if(numRooms >=6 && numRooms <= 10)
        {
            if (treasureSpawns.Length == 1)
            {
                treasureSpawns[0].GetComponent<spawnTreasure>().SpawnTreasureChest();
            }

            else if (treasureSpawns.Length == 2)
            {
                treasureSpawns[0].GetComponent<spawnTreasure>().SpawnTreasureChest();
                treasureSpawns[1].GetComponent<spawnTreasure>().SpawnTreasureChest();
            }
            else if (treasureSpawns.Length >= 3)
            {
                treasureSpawns[0].GetComponent<spawnTreasure>().SpawnTreasureChest();
                treasureSpawns[Random.Range(1,treasureSpawns.Length)].GetComponent<spawnTreasure>().SpawnTreasureChest();
            }
        }
        if(numRooms > 10)
        {
            if (treasureSpawns.Length == 1)
            {
                treasureSpawns[0].GetComponent<spawnTreasure>().SpawnTreasureChest();
            }

            else if (treasureSpawns.Length == 2)
            {
                treasureSpawns[0].GetComponent<spawnTreasure>().SpawnTreasureChest();
                treasureSpawns[1].GetComponent<spawnTreasure>().SpawnTreasureChest();
            }
            else if (treasureSpawns.Length >= 3)
            {
                treasureSpawns[1].GetComponent<spawnTreasure>().SpawnTreasureChest();
                treasureSpawns[Random.Range(2, treasureSpawns.Length)].GetComponent<spawnTreasure>().SpawnTreasureChest();
            }
        }
    }
}

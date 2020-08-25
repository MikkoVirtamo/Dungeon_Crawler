using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomSpawner : MonoBehaviour
{
    public NavMeshSurface surface;
    private int roomcounter;
    [SerializeField]
    private int openingDirection;
    [SerializeField]
    private GameObject lockedDoorIfNoRoom;
    //1 -> bottom door
    //2 -> top door
    //3 -> left door
    //4 -> right door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    private int maxRooms = 15;


    // Start is called before the first frame update
    void Start()
    {
        surface = GameObject.FindGameObjectWithTag("navMeshSurfaceThing").GetComponent<NavMeshSurface>();
        roomcounter = 0;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", .1f);
        //surface.BuildNavMesh();
       // StartCoroutine(BuildNavMeshAfterLevel());
        

    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false && RoomTemplates.numRooms <= RoomTemplates.maxRooms/*maxRooms*/)
        {
            if (openingDirection == 1)
            {
                //need to spawn room with bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                RoomTemplates.numRooms++;
                spawned = true;

            }
            else if (openingDirection == 2)
            {
                //need to spawn room with top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                RoomTemplates.numRooms++;
                spawned = true;
            }
            else if (openingDirection == 3)
            {
                //need to spawn room with left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                RoomTemplates.numRooms++;
                spawned = true;
            }
            else if (openingDirection == 4)
            {
                //need to spawn room with right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                RoomTemplates.numRooms++;
                spawned = true;
            }
            
            
        }
 
    }


   

    //Destroys roomspawner if it would be spawned into a place where a room already exists
    void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
       
    }
}




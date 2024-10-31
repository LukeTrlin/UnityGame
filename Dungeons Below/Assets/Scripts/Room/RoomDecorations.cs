using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDecorations : MonoBehaviour
{
    [SerializeField] int Decorations;
    [SerializeField] GameObject RockDecoration;
    [SerializeField] GameObject GraveDecoration;
    [SerializeField] GameObject TreeDecoration;
    [SerializeField] GameObject RuinDecoration;
    [SerializeField] Transform Room;
    private RoomFunctions roomFunctions;
    private GameObject CurrentRoomDecoration;
    void Start()
    {
        Decorations = Random.Range(1, 4);

        if (Decorations == 1)
        {
            CurrentRoomDecoration = Instantiate(RockDecoration, Room.transform);
            CurrentRoomDecoration.transform.position = new Vector3(Room.transform.position.x + (Random.Range(7, -7)), Room.transform.position.y + (Random.Range(3, -3)), Room.transform.position.z);
        }
        else if (Decorations == 2)
        {
            CurrentRoomDecoration = Instantiate(RuinDecoration, Room.transform);
             
            CurrentRoomDecoration.transform.position = new Vector3(Room.transform.position.x, Room.transform.position.y, Room.transform.position.z);
        }
        else if (Decorations == 3)
        {
            CurrentRoomDecoration = Instantiate(TreeDecoration, Room.transform);
            CurrentRoomDecoration.transform.position = new Vector3(Room.transform.position.x, Room.transform.position.y, Room.transform.position.z);
        }
        else if (Decorations == 4)
        {
            CurrentRoomDecoration = Instantiate(GraveDecoration, Room.transform);
            CurrentRoomDecoration.transform.position = new Vector3(Room.transform.position.x, Room.transform.position.y, Room.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

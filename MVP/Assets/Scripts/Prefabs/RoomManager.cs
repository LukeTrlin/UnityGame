using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Class responsible for managing the room generation in a grid layout
public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject roomPrefab;         // Prefab for regular rooms
    [SerializeField] GameObject startPrefab;        // Prefab for the starting room
    [SerializeField] GameObject bossRoomPrefab;     // Prefab for the boss room

    [SerializeField] private int maxRooms = 15;     // Maximum number of rooms allowed
    [SerializeField] private int minRooms = 10;     // Minimum number of rooms required

    int roomWidth = 40;                              // Width of each room
    int roomHeight = 24;                             // Height of each room
    [SerializeField] public int gridSizeX = 7;      // Width of the grid
    [SerializeField] public int gridSizeY = 6;      // Height of the grid

    private List<GameObject> roomObjects = new List<GameObject>(); // List to store created room objects
    private Queue<Vector2Int> roomQueue = new Queue<Vector2Int>(); // Queue for managing room generation order
    private int[,] roomGrid;                           // 2D array representing the state of the grid
    private int roomCount;                             // Counter for the number of generated rooms
    private bool generationComplete = false;          // Flag indicating if room generation is complete

    // Initializes the room grid and starts the generation process
    private void Start()
    {
        roomGrid = new int[gridSizeX, gridSizeY];   // Create the room grid
        roomQueue = new Queue<Vector2Int>();         // Initialize the room generation queue

        // Start generating rooms from the center of the grid
        Vector2Int initialRoomIndex = new Vector2Int(gridSizeX / 2, gridSizeY / 2);
        StartRoomGenerationFromRoom(initialRoomIndex);
    }

    // Update is called once per frame
    private void Update() 
    {
        // Continue generating rooms until max limit is reached or generation is complete
        if(roomQueue.Count > 0 && roomCount < maxRooms && !generationComplete)
        {
            Vector2Int roomIndex = roomQueue.Dequeue(); // Get the next room index from the queue
            int gridX = roomIndex.x;
            int gridY = roomIndex.y;

            // Attempt to generate rooms in all four directions
            TryGenerateRoom(new Vector2Int(gridX - 1, gridY)); // Left
            TryGenerateRoom(new Vector2Int(gridX + 1, gridY)); // Right
            TryGenerateRoom(new Vector2Int(gridX, gridY + 1)); // Up
            TryGenerateRoom(new Vector2Int(gridX, gridY - 1)); // Down
        }
        else if (roomCount < minRooms) // If the minimum room count is not met, regenerate
        {
            RegenerateRooms();
        }
        else if (!generationComplete) // If generation is complete, instantiate the boss room
        {
            generationComplete = true;
            GameObject lastroom = roomObjects.Last(); // Get the last generated room
            Instantiate(bossRoomPrefab, lastroom.transform.position, Quaternion.identity); // Create the boss room
        }
    }

    // Starts room generation from the specified index
    private void StartRoomGenerationFromRoom(Vector2Int roomIndex)
    {
        roomQueue.Enqueue(roomIndex); // Enqueue the initial room index
        int x = roomIndex.x;
        int y = roomIndex.y;
        roomGrid[x, y] = 1; // Mark this room as generated
        roomCount++; // Increment the room counter

        // Instantiate the starting room and set its properties
        var initialRoom = Instantiate(startPrefab, GetPositionFromGridIndex(roomIndex), Quaternion.identity);
        initialRoom.name = $"room-{roomCount}"; // Name the room
        initialRoom.GetComponent<Room>().RoomIndex = roomIndex; // Set the room index
        roomObjects.Add(initialRoom); // Add the room to the list
    }

    // Attempts to generate a room at a given index
    private bool TryGenerateRoom(Vector2Int roomIndex)
    {
        int x = roomIndex.x;
        int y = roomIndex.y;

        // Check if the room index is within grid bounds
        if (x >= gridSizeX || y >= gridSizeY || x < 0 || y < 0)
            return false;

        // Check if the maximum room count has been reached
        if(roomCount >= maxRooms)
            return false;

        // Randomly decide whether to generate a room (50% chance) unless it's the initial position
        if(Random.value < 0.5f && roomIndex != Vector2Int.zero)
            return false;

        // Ensure no more than one room is adjacent
        if(CountAdjacentRooms(roomIndex) > 1)
            return false;

        // Enqueue the room index for further processing
        roomQueue.Enqueue(roomIndex);
        roomGrid[x, y] = 1; // Mark the room as generated
        roomCount++; // Increment the room count

        // Instantiate the new room
        var newRoom = Instantiate(roomPrefab, GetPositionFromGridIndex(roomIndex), Quaternion.identity);
        newRoom.GetComponent<Room>().RoomIndex = roomIndex; // Set the room index
        
        RoomIdentifier roomIdentifier = newRoom.AddComponent<RoomIdentifier>();
        roomIdentifier.roomID = System.Guid.NewGuid().ToString();
        newRoom.AddComponent<RoomCounter>();
        newRoom.name = $"room-{roomCount}"; // Name the room
        roomObjects.Add(newRoom); // Add the new room to the list

        // Open doors to adjacent rooms if they exist
        OpenDoors(newRoom, x, y);

        return true; // Room generation successful
    }

    // If not between min and max rooms, regenerate
    private void RegenerateRooms() 
    {
        // Destroy all currently generated room objects
        roomObjects.ForEach(Destroy);
        roomObjects.Clear(); // Clear the list of room objects
        roomGrid = new int[gridSizeX, gridSizeY]; // Reset the room grid
        roomQueue.Clear(); // Clear the room queue
        roomCount = 0; // Reset the room count
        generationComplete = false; // Reset the generation flag

        // Start the room generation process again
        Vector2Int initialRoomIndex = new Vector2Int(gridSizeX / 2, gridSizeY / 2);
        StartRoomGenerationFromRoom(initialRoomIndex);
    }

    // Open doors between adjacent rooms based on their positions
    void OpenDoors(GameObject room, int x, int y) 
    {
        Room newRoomScript = room.GetComponent<Room>(); // Get the Room component of the current room

        // Check for neighboring rooms
        Room leftRoomScript = GetRoomScriptAt(new Vector2Int(x - 1, y)); // Left
        Room rightRoomScript = GetRoomScriptAt(new Vector2Int(x + 1, y)); // Right
        Room topRoomScript = GetRoomScriptAt(new Vector2Int(x, y + 1)); // Up
        Room bottomRoomScript = GetRoomScriptAt(new Vector2Int(x, y - 1)); // Down

        // Open doors based on neighboring rooms
        if (x > 0 && roomGrid[x - 1, y] != 0) 
        {
            newRoomScript.OpenDoor(Vector2Int.left); // Open left door
            leftRoomScript.OpenDoor(Vector2Int.right); // Open right door of the left room
        }
        if (x < gridSizeX - 1 && roomGrid[x + 1, y] != 0) 
        {
            newRoomScript.OpenDoor(Vector2Int.right); // Open right door
            rightRoomScript.OpenDoor(Vector2Int.left); // Open left door of the right room
        }
        if (y > 0 && roomGrid[x, y - 1] != 0) 
        {
            newRoomScript.OpenDoor(Vector2Int.down); // Open down door
            bottomRoomScript.OpenDoor(Vector2Int.up); // Open up door of the bottom room
        }
        if (y < gridSizeY - 1 && roomGrid[x, y + 1] != 0) 
        {
            newRoomScript.OpenDoor(Vector2Int.up); // Open up door
            topRoomScript.OpenDoor(Vector2Int.down); // Open down door of the top room
        }
    }

    // Retrieve the Room component at a specific index
    Room GetRoomScriptAt(Vector2Int index) {
        GameObject roomObject = roomObjects.Find(r => r.GetComponent<Room>().RoomIndex == index); // Find the room
        if (roomObject != null)
            return roomObject.GetComponent<Room>(); // Return the Room component if found
        return null; // Return null if not found
    }

    // Count how many adjacent rooms exist around a specified room
    private int CountAdjacentRooms(Vector2Int roomIndex) 
    {
        int x = roomIndex.x;
        int y = roomIndex.y;
        int count = 0;

        // Check each direction for adjacent rooms
        if(x > 0 && roomGrid[x - 1, y] != 0) count++; // Left Neighbour
        if(x < gridSizeX - 1 && roomGrid[x + 1, y] != 0) count++; // Right Neighbour
        if(y > 0 && roomGrid[x, y - 1] != 0) count++; // Bottom Neighbour
        if(y < gridSizeY - 1 && roomGrid[x, y + 1] != 0) count++; // Top Neighbour

        return count; // Return the count of adjacent rooms
    }

    // Get the position from the grid index for room placement
    private Vector3 GetPositionFromGridIndex(Vector2Int gridIndex)
    {
        int gridX = gridIndex.x;
        int gridY = gridIndex.y;
        return new Vector3(roomWidth * (gridX - gridSizeX / 2),
            roomHeight * (gridY - gridSizeY / 2));
    }

    // Draw gizmos for visualizing the grid in the editor
    private void OnDrawGizmos() 
    {
        Color gizmoColor = new Color(0, 1, 1, 0.05f); // Color for the gizmos
        Gizmos.color = gizmoColor;

        // Draw wire cubes for each grid cell
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 position = GetPositionFromGridIndex(new Vector2Int(x, y)); // Get the position
                Gizmos.DrawWireCube(position, new Vector3(roomWidth, roomHeight, 1)); // Draw the cube
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int Width;
    public int Height;
    public int X;
    public int Y;
    public Door leftDoor, rightDoor, topDoor, bottomDoor;
    public List<Door> doors = new List<Door>();

    private void Start()
    {
        if (RoomController.instance == null)
        {
            Debug.Log("RoomController is null");
            return;
        }

        Door[] ds = GetComponentsInChildren<Door>();
        foreach (Door d in ds)
        {
            doors.Add(d);
            switch (d.doorType)
            {
                case DoorType.left:
                    leftDoor = d;
                    break;
                case DoorType.right:
                    rightDoor = d;
                    break;
                case DoorType.top:
                    topDoor = d;
                    break;
                case DoorType.bottom:
                    bottomDoor = d;
                    break;
            }
        }

        RoomController.instance.RegisterRoom(this);
    }

    public void RemoveUnconnectedDoors()
    {
        foreach (Door door in doors)
        {
            switch (door.doorType)
            {
                case DoorType.left:
                    door.gameObject.SetActive(GetLeft() == null);
                    break;
                case DoorType.right:
                    door.gameObject.SetActive(GetRight() == null);
                    break;
                case DoorType.top:
                    door.gameObject.SetActive(GetTop() == null);
                    break;
                case DoorType.bottom:
                    door.gameObject.SetActive(GetBottom() == null);
                    break;
            }
        }
    }

    public Room GetRight()
    {
        return RoomController.instance.DoesRoomExist(X + 1, Y)
            ? RoomController.instance.FindRoom(X + 1, Y)
            : null;
    }

    public Room GetLeft()
    {
        return RoomController.instance.DoesRoomExist(X - 1, Y)
            ? RoomController.instance.FindRoom(X - 1, Y)
            : null;
    }

    public Room GetTop()
    {
        return RoomController.instance.DoesRoomExist(X, Y + 1)
            ? RoomController.instance.FindRoom(X, Y + 1)
            : null;
    }

    public Room GetBottom()
    {
        return RoomController.instance.DoesRoomExist(X, Y - 1)
            ? RoomController.instance.FindRoom(X, Y - 1)
            : null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }

    public Vector3 GetRoomCenter()
    {
        return new Vector3(X * Width, Y * Height);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RoomController.instance.OnPlayerEnterRoom(this);
        }
    }
}

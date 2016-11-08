using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour
{
    static float vertExtent;
    static float horzExtent;

    static float xbound;
    static float ybound;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        xbound = horzExtent * 0.9f;
        ybound = vertExtent * 0.9f;

        Vector3 bottomLeft = new Vector3(-xbound, -ybound);
        Vector3 topRight = new Vector3(xbound, ybound);
        ShipDefinitions.DrawSquare(bottomLeft, topRight, Color.gray, 0.3f);

        bottomLeft = Vector3.zero;
        topRight = Vector3.zero;
    }

    public static Vector3 getPosInBounds(Vector3 position)
    {
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        xbound = horzExtent * 0.9f;
        ybound = vertExtent * 0.9f;
        Vector3 temp = position;

        if (position.x < -xbound)
        {
            temp = new Vector3(xbound, position.y, position.z);
        }
        if (position.x > xbound)
        {
            temp = new Vector3(-xbound, position.y, position.z);
        }
        if (position.y > ybound)
        {
            temp = new Vector3(position.x, -ybound, position.z);
        }
        if (position.y < -ybound)
        {
            temp = new Vector3(position.x, ybound, position.z);
        }
        position = temp;

        return position;
    }
}

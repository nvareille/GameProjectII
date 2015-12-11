using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform PlayerPosition;
    public Vector3 ModifiedCoordinates;
    public Vector3 ModifiedAngles;
    public float LerpSpeed = 1;
	
	// Update is called once per frame
	void Update ()
	{
        if (PlayerPosition != null)
	        transform.position = Vector3.Lerp(transform.position, PlayerPosition.position + ModifiedCoordinates, Time.deltaTime * LerpSpeed);
	    transform.rotation = Quaternion.Euler(ModifiedAngles);
	}
}

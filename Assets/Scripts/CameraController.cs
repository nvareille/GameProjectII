using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Animator Animator;
    public Transform PlayerPosition;
    public Vector3 ModifiedCoordinates;
    public Vector3 ModifiedAngles;
    public float LerpSpeed = 1;

	// Use this for initialization
	void Start ()
	{
	    Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = Vector3.Lerp(transform.position, PlayerPosition.position + ModifiedCoordinates, Time.deltaTime * LerpSpeed);
	    transform.rotation = Quaternion.Euler(ModifiedAngles);
	}

    void SetFollowingObject(GameObject obj)
    {
        PlayerPosition = obj.transform;
    }

    void TryTakePossess()
    {
        Animator.SetBool("Focusing", true);
    }

    void StopTakePocess()
    {
        Animator.SetBool("Focusing", false);
    }
}

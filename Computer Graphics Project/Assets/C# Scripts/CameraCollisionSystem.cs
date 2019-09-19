using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionSystem : MonoBehaviour
{
    // Create variables here.
    public float miniDistance = 2.0f;
    public float maxiDistance = 6.0f;
    public float smoothing = 15.0f;
    private float distance = 0.0f;
    private Vector3 dolly = Vector3.zero;
    private Vector3 dollyAdju = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Create variables exclusive to this function here.
        RaycastHit rcHit = new RaycastHit();
        Vector3 cameraPosition = this.transform.parent.TransformPoint(dolly * maxiDistance);

        /*
        if (Input.GetMouseButton(1))
        {
            // Adjust our distance accordingly depending on if we hit an object or not.
            if (Physics.Linecast(this.transform.parent.position, cameraPosition, out rcHit))
            {
                distance = Mathf.Clamp(rcHit.distance * 10.1f, miniDistance, maxiDistance);
            }
            else
            {
                distance = maxiDistance;
            }

            // Assign a new position that does not clip with an object near the camera.
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, dolly * distance, Time.deltaTime * smoothing);
        }
        */
    }

    void Awake()
    {
        // Get the object's normalized position.
        dolly = this.transform.localPosition.normalized;

        // Get the object's distance.
        distance = this.transform.localPosition.magnitude;
    }
}

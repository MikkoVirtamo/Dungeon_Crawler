using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float height = 10f;
    public float distance = 20f;
    public float angle = 45f;
    // Start is called before the first frame update
    void Start()
    {
        HandleCamera();
    }

    // Update is called once per frame
    void Update()
    {
        
        //this.gameObject.transform.eulerAngles.y = 0;
        HandleCamera();
    }

    protected virtual void HandleCamera()
    {
        transform.localEulerAngles = new Vector3(85, 0, 0);
        if (!target)
        {
            return;
        }
        transform.LookAt(target);
        Vector3 worldPosition = (Vector3.forward * distance) + (Vector3.up * height);
        //Debug.DrawLine(target.position, worldPosition, Color.red);

        Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * worldPosition;
        //Debug.DrawLine(target.position, rotatedVector, Color.green);

        Vector3 flatTargetPosition = target.position;
        flatTargetPosition.y = 0;
        Vector3 finalPosition = flatTargetPosition + rotatedVector;

        transform.position = finalPosition;

    }


}

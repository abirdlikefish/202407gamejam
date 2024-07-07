using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 nextCheck;
    public float moveLen;

    private void Update()
    {
        Vector3 target = new Vector3(nextCheck.x-moveLen/2, nextCheck.y, -10);
        //Vector3 target = new Vector3(nextCheck.x, nextCheck.y, -10);
        
        //if(target.x - transform.position.x <=0.01)return;
        
        float lerp = Mathf.Abs(target.x - transform.position.x ) / (moveLen/2);

        transform.position = Vector3.Lerp(transform.position, target, lerp);
    }

}

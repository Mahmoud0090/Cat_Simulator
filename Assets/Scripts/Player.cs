using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Touch touch;
    public float speed;
    public float posXMax;
    public float posXMin;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speed,
                    transform.position.y,
                    transform.position.z
                    );
            }
        }

        if(transform.position.x >= posXMax)
        {
            transform.position = new Vector3(
                   posXMax,
                   transform.position.y,
                   transform.position.z
                   );
        }

        if (transform.position.x <= posXMin)
        {
            transform.position = new Vector3(
                   posXMin,
                   transform.position.y,
                   transform.position.z
                   );
        }

    }
}

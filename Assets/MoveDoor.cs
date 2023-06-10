using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    public float moveDuration = 5;
    public Vector3 target = new Vector3(0, 0, 0);
    Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {   
        print(!transform.hasChanged);
        if (!transform.hasChanged)
        {
            print("THING HAS CHANGED");
            StartCoroutine(MoveCube(target));
            transform.hasChanged = true;
        }
    }

    public IEnumerator MoveCube(Vector3 targetPosition) 
    {
        Vector3 startPosition = transform.position;
        float timeElapsed = 0;

        while(timeElapsed < moveDuration) 
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed/moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }

}

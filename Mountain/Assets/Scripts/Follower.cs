using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;


//public class NewBehaviourScript : MonoBehaviour
//using{

public class Follower : MonoBehaviour {

    public PathCreator pathCreator;
    public float speed = 1;
    float distanceTravelled;
    
        // Update is called once per frame
    void Update() {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        
    }
}


// Start is called before the first frame update
//void Start()
//{

//}
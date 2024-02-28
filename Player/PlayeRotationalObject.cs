using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeRotationalObject : MonoBehaviour
{

    [SerializeField] private GameObject rotationGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Get the rotational object on the play rotation. This because this script will go on the rotational oobject
        Vector3 rotationalObjectPos = rotationGameObject.transform.position;
        //gett rotation
        //I did the mannual math, which essentially is imagining (in a ScreenToWorldPoint wherre 0,0 is the center of the screen)
        /* imagine having a player at 4 difference positions with 4 difference mouse positions exactly 1 vector diagnoly away, eg:
        
        Point 1 (quadrantt 1): Player (1,1), mouse (2,2)
        Point 2 (quadrantt 2): Player (-1,1), mouse (-2,2)
        Point 3 (quadrantt 3): Player (-1,-1), mouse (-2,-2)
        Point 4 (quadrantt 4): Player (1,-1), mouse (2,-2)

        substracting the player from tthe mouse positiion always gives you the direction relative to the center(the playerr) tthe mouse is
        */
        Vector3 rotation = mousePos - rotationalObjectPos;
        //get Rotz in rradians
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        // rrotate thee object
        rotationGameObject.transform.rotation = Quaternion.Euler(0,0,rotZ);
        
    }
}

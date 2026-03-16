using UnityEngine;

//use this on 2d assets that need to face the player. text, sprites, etc.
public class LookAtPlayer : MonoBehaviour
{
    private Transform trans;
    private Vector3 offset = new Vector3(0, 180, 0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //assign axis to look at the camera
        trans = GameObject.Find("FPcam").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //keep view on camera
        transform.LookAt(trans);
        //flip it so it's not backwards in game
        transform.Rotate(offset);
    }
}

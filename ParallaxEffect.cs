using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxEffect : MonoBehaviour
{
    [Tooltip("camera reference to which parallax needs to be calculated ")]
    [SerializeField] private Camera camera; // camera reference to which parallax needs to be calculated  

    private float intialPos, offsetPos;
    
    [Tooltip("define length of the sprite")]
    [SerializeField] private float length; // length of the sprite

    [Tooltip("define value between 0-1 for the speed of parallax")]
    [SerializeField] private float parallax; // speed of parallax. nearest sprite will have value close to 0 and furthest will have close to 1
    
    private void Start()
    {
        intialPos = transform.position.y;
        offsetPos = intialPos;
    }

    //
    // note:
    //      You can put this logic in update loop if you dont want to use coroutine.
    //      if you are using this coroutine make sure to stop this current coroutine if level is completed or if you don't need it.
    //
    public IEnumerator UpdateBg()
    {
        while(true)
        {
            //
            //  Summary:
            //      Parallax logic
            //
            float distance = camera.transform.position.y * parallax;

            transform.position = new Vector3(transform.position.x, offsetPos + distance, transform.position.z);


            //
            //  Summmary:
            //      loops the sprites according to the camera position
            //
            if (camera.transform.position.y < transform.position.y - length)
            {
                offsetPos -= length * 2;
            }
            else if (camera.transform.position.y > transform.position.y + length)
            {
                offsetPos += length * 2;
            }

            yield return null;
        }
    }
}

using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    private float startpos, length;
    public GameObject cam;
    public float parallaxEffect; // Speed at which the background should move relative to the camera

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        // Calculate distance background move based on camera movement
        float distance = cam.transform.position.x * parallaxEffect; // 1 = move with cam, 0 = don't move, 0.5 = half
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

        // If background reaches the end of its length, adjust position for infinite scrolling
        if (movement > startpos + length)
        {
            startpos += length;
        }
        else if (movement < startpos - length)
        {
            startpos -= length;
        }
    }
}

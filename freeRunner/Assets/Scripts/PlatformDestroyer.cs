using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformDestrucationPoint;

    // Start is called before the first frame update
    void Start()
    {
        platformDestrucationPoint = GameObject.Find("PlatformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < platformDestrucationPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);

        }
    }
}

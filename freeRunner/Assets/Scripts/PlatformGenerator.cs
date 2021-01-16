using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform generationPoint;

    public ObjectPooler[] theObjectPools;
    private float[] platformsWidths;

    //random number to select platform from pools
    private int platformSelector;


    private float distanceBetween;
    public float distanceBetweeMin;
    public float distanceBetweeMax;


    //height related
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    // Start is called before the first frame update
    void Start()
    {
        platformsWidths = new float[theObjectPools.Length];
        for (int i = 0; i < platformsWidths.Length; i++)
        {
            platformsWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweeMin, distanceBetweeMax);
            heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);
            heightChange = System.Math.Min(maxHeight, heightChange);
            heightChange = System.Math.Max(minHeight, heightChange);

            platformSelector = Random.Range(0, theObjectPools.Length);

            transform.position = new Vector3(transform.position.x + (platformsWidths[platformSelector] / 2) + distanceBetween,
                                             heightChange,
                                             transform.position.z);


            GameObject freePlatform = theObjectPools[platformSelector].GetPooledObject();
            freePlatform.transform.position = transform.position;
            freePlatform.transform.rotation = transform.rotation;
            freePlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformsWidths[platformSelector] / 2),
                                             transform.position.y,
                                             transform.position.z);
        }
    }
}

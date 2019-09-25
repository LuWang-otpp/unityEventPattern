using UnityEngine;

public class LocalCoordinate : MonoBehaviour
{


    //obj
    [SerializeField] private GameObject cubeObj;
    [SerializeField] private GameObject localCoordinateObj;
    //script
    [SerializeField] private Controller controller;

    //vars
    private float orgLocalX, orgLocalY;
    private float Rotate = 0;
    private float orgLocalScaleX, orgLocalScaleY;
    private Vector3 localPosition = new Vector3(0, 0, 0);
    private Vector3 localScale;
    private Vector3 cubePosition = new Vector3(0, 0, 0);
    private void Start()
    {
        //init locations
        orgLocalX = localCoordinateObj.transform.localPosition.x;
        orgLocalY = localCoordinateObj.transform.localPosition.y;
        orgLocalScaleX = localCoordinateObj.transform.localScale.x;
        orgLocalScaleY = localCoordinateObj.transform.localScale.y;
        localScale = new Vector3(orgLocalScaleX, orgLocalScaleY, 0);

        //add listener
        controller.localCoordinateChanged += localCoordinateChange;
        controller.localRotateChanged += localRotateChange;
        controller.localScaleChanged += localScaleChange;
    }

    private void localCoordinateChange(object sender, coordinateEventIntArgs e)
    {
        float tmpX = e.x;
        float tmpY = e.y;

        localPosition.x = tmpX + orgLocalX;
        localPosition.y = tmpY + orgLocalY;
        ;
        localCoordinateObj.transform.localPosition = localPosition;
    }

    private void localRotateChange(object sender, rotateEventIntArgs e)
    {
        Quaternion tmpD = e.d;

        localCoordinateObj.transform.localRotation = tmpD;
    }

    private void localScaleChange(object sender, coordinateEventIntArgs e)
    {
        float tmpX = e.x;
        float tmpY = e.y;

        if (tmpX == 0) tmpX = 0.01f;
        if (tmpY == 0) tmpY = 0.01f;

        localScale.x = orgLocalScaleX * tmpX;
        localScale.y = orgLocalScaleY * tmpY;

        localCoordinateObj.transform.localScale = localScale;
    }
}


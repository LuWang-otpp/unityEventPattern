using UnityEngine;

public class Cube : MonoBehaviour
{
    //obj
    [SerializeField] private GameObject cubeObj;
    [SerializeField] private GameObject localCoordinateObj;
    //script
    [SerializeField] private Controller controller;

    //vars
    private float orgCubeX = 0;
    private float orgCubeY = 0;
    private float orgLocalScaleX, orgLocalScaleY;
    private Vector3 cubePosition = new Vector3(0, 0, 0);
    private Vector3 cubeScale;

    private void Start()
    {
        //init locations
        orgCubeX = cubeObj.transform.localPosition.x;
        orgCubeY = cubeObj.transform.localPosition.y;
        orgLocalScaleX = localCoordinateObj.transform.localScale.x;
        orgLocalScaleY = localCoordinateObj.transform.localScale.y;

        //add listener
        controller.cubeChanged += cubeChange;
        controller.localScaleChanged += localScaleChange;
    }


    private void cubeChange(object sender, coordinateEventIntArgs e)
    {
        cubePosition.x = orgCubeX + e.x / orgLocalScaleX;
        cubePosition.y = orgCubeY + e.y / orgLocalScaleY;

        cubeObj.transform.localPosition = cubePosition;
    }
    private void localScaleChange(object sender, coordinateEventIntArgs e)
    {
        float tmpX = e.x;
        float tmpY = e.y;

        if (tmpX == 0) tmpX = 0.01f;
        if (tmpY == 0) tmpY = 0.01f;

        cubeScale.x = 1 / tmpX;
        cubeScale.y = 1 / tmpY;
        cubeObj.transform.localScale = cubeScale;
    }
}

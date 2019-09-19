using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    [SerializeField] private GameObject cubeObj;
    [SerializeField] private GameObject localCoordinateObj;

    private float orgCubeX = 0, orgCubeY = 0;
    private float orgLocalScaleX, orgLocalScaleY;

    private Vector3 cubePosition = new Vector3(0, 0, 0);
    private Vector3 cubeScale;

    // private void Start()
    // {
    //     orgCubeX = cubeObj.transform.localPosition.x;
    //     orgCubeY = cubeObj.transform.localPosition.y;

    //     orgLocalScaleX = localCoordinateObj.transform.localScale.x;
    //     orgLocalScaleY = localCoordinateObj.transform.localScale.y;
    // }

}

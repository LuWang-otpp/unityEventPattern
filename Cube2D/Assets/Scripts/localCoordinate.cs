using UnityEngine;
using UnityEngine.UI;

public class localCoordinate : MonoBehaviour
{
    private float orgLocalX, orgLocalY;
    private float Rotate = 0;
    private float orgLocalScaleX, orgLocalScaleY;
    private float orgCubeX = 0, orgCubeY = 0;

    private Vector3 localPosition = new Vector3(0, 0, 0);
    private Vector3 localScale;
    private Vector3 cubePosition = new Vector3(0, 0, 0);
    private Vector3 cubeScale;

    //obj
    [SerializeField] private GameObject cubeObj;
    [SerializeField] private GameObject localCoordinateObj;
    //inputes
    [SerializeField] private InputField localXInpute;
    [SerializeField] private InputField localYInpute;
    [SerializeField] private InputField localRotateInpute;
    [SerializeField] private InputField localScaleXInpute;
    [SerializeField] private InputField localScaleYInpute;
    [SerializeField] private InputField cubeXInpute;
    [SerializeField] private InputField cubeYInpute;
    private void Start()
    {

        orgLocalX = localCoordinateObj.transform.localPosition.x;
        orgLocalY = localCoordinateObj.transform.localPosition.y;
        orgLocalScaleX = localCoordinateObj.transform.localScale.x;
        orgLocalScaleY = localCoordinateObj.transform.localScale.y;
        localScale = new Vector3(orgLocalScaleX, orgLocalScaleY, 0);
        orgCubeX = cubeObj.transform.localPosition.x;
        orgCubeY = cubeObj.transform.localPosition.y;

        localXInpute.onValueChanged.AddListener(delegate { localCoordinateChange(); });
        localYInpute.onValueChanged.AddListener(delegate { localCoordinateChange(); });
        localRotateInpute.onValueChanged.AddListener(delegate { localRotateChange(); });
        localScaleXInpute.onValueChanged.AddListener(delegate { localScaleChange(); });
        localScaleYInpute.onValueChanged.AddListener(delegate { localScaleChange(); });
        cubeXInpute.onValueChanged.AddListener(delegate { cubeChange(); });
        cubeYInpute.onValueChanged.AddListener(delegate { cubeChange(); });

    }

    private void localCoordinateChange()
    {
        float tmpX = localXInpute.text == "" ? 0 : float.Parse(localXInpute.text);
        float tmpY = localYInpute.text == "" ? 0 : float.Parse(localYInpute.text);

        localPosition.x = tmpX + orgLocalX;
        localPosition.y = tmpY + orgLocalY;
        ;
        localCoordinateObj.transform.localPosition = localPosition;
    }

    private void localRotateChange()
    {
        float tmp = localRotateInpute.text == "" ? 0 : float.Parse(localRotateInpute.text);
        tmp = tmp % 360;

        Quaternion tmpQ = Quaternion.Euler(0, 0, tmp);

        localCoordinateObj.transform.localRotation = tmpQ;
    }

    private void localScaleChange()
    {
        float tmpX = localScaleXInpute.text == "" ? 0 : float.Parse(localScaleXInpute.text);
        float tmpY = localScaleYInpute.text == "" ? 0 : float.Parse(localScaleYInpute.text);

        if (tmpX == 0) tmpX = 0.01f;
        if (tmpY == 0) tmpY = 0.01f;

        localScale.x = orgLocalScaleX * tmpX;
        localScale.y = orgLocalScaleY * tmpY;

        cubeScale.x = 1 / tmpX;
        cubeScale.y = 1 / tmpY;
        cubeObj.transform.localScale = cubeScale;
        localCoordinateObj.transform.localScale = localScale;
    }

    private void cubeChange()
    {
        float tmpX = cubeXInpute.text == "" ? 0 : float.Parse(cubeXInpute.text);
        float tmpY = cubeYInpute.text == "" ? 0 : float.Parse(cubeYInpute.text);

        cubePosition.x = orgCubeX + tmpX / orgLocalScaleX;
        cubePosition.y = orgCubeY + tmpY / orgLocalScaleY;

        cubeObj.transform.localPosition = cubePosition;
    }
}


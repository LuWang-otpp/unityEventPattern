using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public void localCoordinateChange()
    {
        float tmpX = localXInpute.text == "" ? 0 : float.Parse(localXInpute.text);
        float tmpY = localYInpute.text == "" ? 0 : float.Parse(localYInpute.text);

        localPosition.x = tmpX + orgLocalX;
        localPosition.y = tmpY + orgLocalY;
        ;
        localCoordinateObj.transform.localPosition = localPosition;
    }

    public void localRotateChange()
    {
        float tmp = localRotateInpute.text == "" ? 0 : float.Parse(localRotateInpute.text);
        tmp = tmp % 360;

        Quaternion tmpQ = Quaternion.Euler(0, 0, tmp);

        localCoordinateObj.transform.localRotation = tmpQ;
    }

    public void localScaleChange()
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

    public void cubeChange()
    {
        float tmpX = cubeXInpute.text == "" ? 0 : float.Parse(cubeXInpute.text);
        float tmpY = cubeYInpute.text == "" ? 0 : float.Parse(cubeYInpute.text);

        cubePosition.x = orgCubeX + tmpX / orgLocalScaleX;
        cubePosition.y = orgCubeY + tmpY / orgLocalScaleY;

        cubeObj.transform.localPosition = cubePosition;
    }
}

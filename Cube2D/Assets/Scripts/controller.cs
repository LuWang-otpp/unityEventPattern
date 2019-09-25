using System;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] private Inputs inputes;

    private void Start()
    {
        inputes.localCoordinateChanged += localCoordinateChange;
        inputes.localRotateChanged += localRotateChange;
        inputes.localScaleChanged += localScaleChange;
        inputes.cubeChanged += cubeChange;
    }

    private void localCoordinateChange(object sender, coordinateEventArgs e)
    {
        float tmpX = e.x == "" ? 0 : float.Parse(e.x);
        float tmpY = e.y == "" ? 0 : float.Parse(e.y);

        coordinateEventIntArgs args = new coordinateEventIntArgs(tmpX, tmpY);
        EventHandler<coordinateEventIntArgs> handler = localCoordinateChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }

    private void localRotateChange(object sender, rotateEventArgs e)
    {
        float tmp = e.d == "" ? 0 : float.Parse(e.d);
        tmp = tmp % 360;

        Quaternion tmpQ = Quaternion.Euler(0, 0, tmp);

        rotateEventIntArgs args = new rotateEventIntArgs(tmpQ);
        EventHandler<rotateEventIntArgs> handler = localRotateChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }

    private void localScaleChange(object sender, coordinateEventArgs e)
    {
        float tmpX = e.x == "" ? 0 : float.Parse(e.x);
        float tmpY = e.y == "" ? 0 : float.Parse(e.y);

        if (tmpX == 0) tmpX = 0.01f;
        if (tmpY == 0) tmpY = 0.01f;

        coordinateEventIntArgs args = new coordinateEventIntArgs(tmpX, tmpY);
        EventHandler<coordinateEventIntArgs> handler = localScaleChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }

    private void cubeChange(object sender, coordinateEventArgs e)
    {
        float tmpX = e.x == "" ? 0 : float.Parse(e.x);
        float tmpY = e.y == "" ? 0 : float.Parse(e.y);

        coordinateEventIntArgs args = new coordinateEventIntArgs(tmpX, tmpY);
        EventHandler<coordinateEventIntArgs> handler = cubeChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }

    public event EventHandler<coordinateEventIntArgs> localCoordinateChanged;
    public event EventHandler<rotateEventIntArgs> localRotateChanged;
    public event EventHandler<coordinateEventIntArgs> localScaleChanged;
    public event EventHandler<coordinateEventIntArgs> cubeChanged;
}

public class coordinateEventIntArgs : EventArgs
{
    public float x, y;

    public coordinateEventIntArgs(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}

public class rotateEventIntArgs : EventArgs
{
    public Quaternion d;

    public rotateEventIntArgs(Quaternion d)
    {
        this.d = d;
    }
}
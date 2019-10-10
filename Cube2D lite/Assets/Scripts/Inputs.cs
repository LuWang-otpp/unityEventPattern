using System;
using UnityEngine;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{
    [SerializeField] private InputField localXInpute;
    [SerializeField] private InputField localYInpute;
    [SerializeField] private InputField localRotateInpute;
    [SerializeField] private InputField localScaleXInpute;
    [SerializeField] private InputField localScaleYInpute;
    [SerializeField] private InputField cubeXInpute;
    [SerializeField] private InputField cubeYInpute;

    /*    private event EventHandler localCoordinateChangeHandler;
        private event EventHandler localRotateChangeHandler;
        private event EventHandler localScaleChangeHandler;
        private event EventHandler cubeChangeHandler;*/
    private void Start()
    {

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
        coordinateEventArgs args = new coordinateEventArgs(localXInpute.text, localYInpute.text);

        EventHandler<coordinateEventArgs> handler = localCoordinateChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }

    private void localRotateChange()
    {
        rotateEventArgs args = new rotateEventArgs(localRotateInpute.text);

        EventHandler<rotateEventArgs> handler = localRotateChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }

    private void localScaleChange()
    {
        coordinateEventArgs args = new coordinateEventArgs(localScaleXInpute.text, localScaleYInpute.text);

        EventHandler<coordinateEventArgs> handler = localScaleChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }

    private void cubeChange()
    {
        coordinateEventArgs args = new coordinateEventArgs(cubeXInpute.text, cubeYInpute.text);

        EventHandler<coordinateEventArgs> handler = cubeChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }

    public event EventHandler<coordinateEventArgs> localCoordinateChanged;
    public event EventHandler<rotateEventArgs> localRotateChanged;
    public event EventHandler<coordinateEventArgs> localScaleChanged;
    public event EventHandler<coordinateEventArgs> cubeChanged;


}

public class coordinateEventArgs : EventArgs
{
    public string x, y;

    public coordinateEventArgs(string x, string y)
    {
        this.x = x;
        this.y = y;
    }
}

public class rotateEventArgs : EventArgs
{
    public string d;

    public rotateEventArgs(string d)
    {
        this.d = d;
    }
}
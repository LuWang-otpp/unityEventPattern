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

    public event EventHandler localCoordinateChangeHandler;

    private void Start()
    {

        localXInpute.onValueChanged.AddListener(delegate { localCoordinateChange(); });
        localYInpute.onValueChanged.AddListener(delegate { localCoordinateChange(); });
        /*        localRotateInpute.onValueChanged.AddListener(delegate { () => controller.localRotateChange(localRotateInpute.text); });
                localScaleXInpute.onValueChanged.AddListener(delegate { () => controller.localScaleChange(localScaleXInpute.text, localScaleYInpute.text); });
                localScaleYInpute.onValueChanged.AddListener(delegate { () => controller.localScaleChange(localScaleXInpute.text, localScaleYInpute.text); });
                cubeXInpute.onValueChanged.AddListener(delegate { () => controller.cubeChange(cubeXInpute.text, cubeYInpute.text); });
                cubeYInpute.onValueChanged.AddListener(delegate { () => controller.cubeChange(cubeXInpute.text, cubeYInpute.text); });*/
    }

    private void localCoordinateChange()
    {
        coordinateEventArgs args = new coordinateEventArgs();
        args.x = localXInpute.text;
        args.y = localYInpute.text;

        EventHandler<coordinateEventArgs> handler = localCoordinateChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }

    public event EventHandler<coordinateEventArgs> localCoordinateChanged;

}

public class coordinateEventArgs : EventArgs
{
    public string x, y;
}
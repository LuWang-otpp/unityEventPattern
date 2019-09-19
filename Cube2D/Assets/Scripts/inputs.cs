using UnityEngine;
using UnityEngine.UI;

public class inputs : MonoBehaviour
{
    [SerializeField] private InputField localXInpute;
    [SerializeField] private InputField localYInpute;
    [SerializeField] private InputField localRotateInpute;
    [SerializeField] private InputField localScaleXInpute;
    [SerializeField] private InputField localScaleYInpute;
    [SerializeField] private InputField cubeXInpute;
    [SerializeField] private InputField cubeYInpute;

    private void Start()
    {
        localXInpute.onValueChanged.AddListener(delegate { () => controller.localCoordinateChange(localXInpute.text, localYInpute.text); });
        localYInpute.onValueChanged.AddListener(delegate { () => controller.localCoordinateChange(localXInpute.text, localYInpute.text); });
        localRotateInpute.onValueChanged.AddListener(delegate { () => controller.localRotateChange(localRotateInpute.text); });
        localScaleXInpute.onValueChanged.AddListener(delegate { () => controller.localScaleChange(localScaleXInpute.text, localScaleYInpute.text); });
        localScaleYInpute.onValueChanged.AddListener(delegate { () => controller.localScaleChange(localScaleXInpute.text, localScaleYInpute.text); });
        cubeXInpute.onValueChanged.AddListener(delegate { () => controller.cubeChange(cubeXInpute.text, cubeYInpute.text); });
        cubeYInpute.onValueChanged.AddListener(delegate { () => controller.cubeChange(cubeXInpute.text, cubeYInpute.text); });
    }
}

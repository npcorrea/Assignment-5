using UnityEngine.UI;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Button cam;
    public Camera fp;
    public Camera tp;
    private bool firstPerson;

    // Start is called before the first frame update
    void Start()
    {
        // start with third person camera
        firstPerson = false;
        cam.onClick.AddListener(SwitchOnClick);
    }

    // when button clicked make firstPerson true/false
    void SwitchOnClick()
    {
        if (firstPerson == false)
        {
            firstPerson = true;
        }
        else
        {
            firstPerson = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // enables third person camera
        if (firstPerson == false)
        {
            tp.enabled = true;
            fp.enabled = false;
        }
        // enables first person camera
        else
        {
            tp.enabled = false;
            fp.enabled = true;
        }
    }
}

using UnityEngine;

public class Showroom3DInputController : MonoBehaviour
{
    public float CurrentMouseX;
    public float CurrentMouseY;
    public bool CurrentRightMouseButtonClicked;

    // intended for Quit?, but not required
    public bool EscapeKeyWasPushed;

    public bool Enabled;

    // Start is called before the first frame update
    void Start()
    {
        CurrentRightMouseButtonClicked = false;
        EscapeKeyWasPushed = false;
        Enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // only update sensed inputs if we are enabled
        if (Enabled)
        {
            CurrentMouseX = Input.GetAxisRaw("Mouse X");
            CurrentMouseY = Input.GetAxisRaw("Mouse Y");

            if (Input.GetMouseButtonDown(1))
            {
                CurrentRightMouseButtonClicked = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                CurrentRightMouseButtonClicked = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EscapeKeyWasPushed = true;
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                EscapeKeyWasPushed = false;
            }
        }
    }
}

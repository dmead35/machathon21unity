using UnityEngine;

public class Showroom3DCameraController : MonoBehaviour
{
    public Showroom3DInputController inputController;
    protected const float rotationScaleInBarrelRollRotationDegreesPerInputValue = 40.0f;
    protected const float rotationScaleInYawRotationDegreesPerInputValue = 40.0f;
    protected const float rotationScaleInPitchRotationDegreesPerInputValue = 40.0f;

    Vector2 rotation = Vector2.zero;
    public float speed = 3;

    protected enum CameraMovementModes
    {
        DoNothing = 0,
        Pitch = 1,
        Yaw = 2,
        BarrelRoll = 3
    }

    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;
        // UpdateCameraDirection();
    }

    protected void UpdateCameraDirection()
    {
        var cameraMovementModeSelection = DetermineWhichCameraMovementModeToHonor();

        switch (cameraMovementModeSelection)
        {
            case CameraMovementModes.BarrelRoll:
                var currentMouseX = inputController.CurrentMouseX;
                var degreesToRotateZ = currentMouseX * rotationScaleInBarrelRollRotationDegreesPerInputValue;
                BarrelRollCamera(degreesToRotateZ);
                break;
            case CameraMovementModes.Yaw:
                currentMouseX = inputController.CurrentMouseX;
                var degreesToRotateX = currentMouseX * rotationScaleInYawRotationDegreesPerInputValue;
                YawCamera(degreesToRotateX);
                break;
            case CameraMovementModes.Pitch:
                var currentMouseY = inputController.CurrentMouseY;
                var degreesToPitchY = currentMouseY * rotationScaleInPitchRotationDegreesPerInputValue;
                PitchCamera(degreesToPitchY);
                break;
            default:
                break;

        }
    }

    protected CameraMovementModes DetermineWhichCameraMovementModeToHonor()
    {
        var returnValue = CameraMovementModes.DoNothing;

        if (inputController.CurrentRightMouseButtonClicked)
        {
            // right click mode dominates everything
            returnValue = CameraMovementModes.BarrelRoll;
        }
        else
        {
            var isXDisplacementBiggerThanYDisplacement = false;

            var xDisplacement = Mathf.Abs(inputController.CurrentMouseX);
            var yDisplacement = Mathf.Abs(inputController.CurrentMouseY);

            if (xDisplacement > yDisplacement)
            {
                isXDisplacementBiggerThanYDisplacement = true;
            }

            if (isXDisplacementBiggerThanYDisplacement)
            {
                returnValue = CameraMovementModes.Yaw;
            }
            else
            {
                returnValue = CameraMovementModes.Pitch;
            }
        }

        return returnValue;
    }


    protected void BarrelRollCamera(float howMuch)
    {
        // switch positive to negative
        howMuch *= -1.0f;
        transform.Rotate(Vector3.forward, howMuch, Space.Self);
    }

    protected void PitchCamera(float howMuch)
    {
        // switch positive to negative
        howMuch *= -1.0f;
        transform.Rotate(Vector3.right, howMuch, Space.Self);
    }

    protected void YawCamera(float howMuch)
    {
        transform.Rotate(Vector3.up, howMuch, Space.Self);
    }
}
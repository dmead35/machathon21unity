using UnityEngine;
using UnityEngine.UI;

public class Showroom3DCameraController : MonoBehaviour
{
    public Showroom3DInputController inputController;
    public Canvas uiCanvas;
    Vector2 rotation = Vector2.zero;
    public float speed = 3;

    protected Transform panel;
    protected Transform textBench1;
    protected Transform textBag1;
    protected Transform textBench2;
    protected Transform textBag2;
    protected Transform textTreadmill;
    protected Transform log;

    void Start()
    {
        panel = uiCanvas.transform.Find("StoreProductInfoPanel");
        textBench1 = panel.transform.Find("Bench1Info");
        textBag1 = panel.transform.Find("PunchingBag1Info");
        textBench2 = panel.transform.Find("Bench2Info");
        textTreadmill = panel.transform.Find("TreadmillInfo");
        textBag2 = panel.transform.Find("PunchingBag2Info");
        log = panel.transform.Find("Log");
        panel.gameObject.SetActive(false);
    }

    void Update()
    {
        // mouselook
        // found technique via a google search
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;

        var cameraDirection = new Ray(this.transform.position, this.transform.forward);

        bool hitTreadmill = false;
        bool hitBench1 = false;
        bool hitBench2 = false;
        bool hitBag1 = false;
        bool hitBag2 = false;

        if (Physics.Raycast(cameraDirection, out RaycastHit hitInfo))
        {
            if ((hitInfo.collider != null)
                && (hitInfo.collider.gameObject != null))
            {
                var collidedObjectName = hitInfo.collider.gameObject.name;

                switch (collidedObjectName.ToLower())
                {
                    case "gym bench 001_leather":
                        hitTreadmill = false;
                        hitBench1 = false;
                        hitBench2 = true;
                        hitBag1 = false;
                        hitBag2 = false;
                        break;
                    case "cylinder":
                        hitTreadmill = false;
                        hitBench1 = false;
                        hitBench2 = false;
                        hitBag1 = false;
                        hitBag2 = true;
                        break;
                    case "cube.018":
                        hitTreadmill = false;
                        hitBench1 = true;
                        hitBench2 = false;
                        hitBag1 = false;
                        hitBag2 = false;
                        break;
                    case "belt":
                        hitTreadmill = true;
                        hitBench1 = false;
                        hitBench2 = false;
                        hitBag1 = false;
                        hitBag2 = false;
                        break;
                    case "cylinder.001":
                        hitTreadmill = false;
                        hitBench1 = false;
                        hitBench2 = false;
                        hitBag1 = true;
                        hitBag2 = false;
                        break;
                    default:
                        hitTreadmill = false;
                        hitBench1 = false;
                        hitBench2 = false;
                        hitBag1 = false;
                        hitBag2 = false;
                        //var text = log.GetComponent<Text>();
                        //text.text = collidedObjectName.ToLower();
                        break;
                }

                if (hitTreadmill)
                {
                    panel.gameObject.SetActive(true);
                    textTreadmill.gameObject.SetActive(true);
                    textBench1.gameObject.SetActive(false);
                    textBench2.gameObject.SetActive(false);
                    textBag1.gameObject.SetActive(false);
                    textBag2.gameObject.SetActive(false);
                }
                else if (hitBench1)
                {
                    panel.gameObject.SetActive(true);
                    textTreadmill.gameObject.SetActive(false);
                    textBench1.gameObject.SetActive(true);
                    textBench2.gameObject.SetActive(false);
                    textBag1.gameObject.SetActive(false);
                    textBag2.gameObject.SetActive(false);
                }
                else if (hitBench2)
                {
                    panel.gameObject.SetActive(true);
                    textTreadmill.gameObject.SetActive(false);
                    textBench1.gameObject.SetActive(false);
                    textBench2.gameObject.SetActive(true);
                    textBag1.gameObject.SetActive(false);
                    textBag2.gameObject.SetActive(false);
                }
                else if (hitBag1)
                {
                    panel.gameObject.SetActive(true);
                    textTreadmill.gameObject.SetActive(false);
                    textBench1.gameObject.SetActive(false);
                    textBench2.gameObject.SetActive(false);
                    textBag1.gameObject.SetActive(true);
                    textBag2.gameObject.SetActive(false);
                }
                else if (hitBag2)
                {
                    panel.gameObject.SetActive(true);
                    textTreadmill.gameObject.SetActive(false);
                    textBench1.gameObject.SetActive(false);
                    textBench2.gameObject.SetActive(false);
                    textBag1.gameObject.SetActive(false);
                    textBag2.gameObject.SetActive(true);
                }
                else
                {
                    panel.gameObject.SetActive(false);
                }
            }
        }
    }
}
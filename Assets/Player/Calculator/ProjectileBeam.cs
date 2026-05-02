using UnityEngine;
using System.Collections;

public class ProjectileBeam : MonoBehaviour
{
    CalcLogic calcLogic;

    public GameObject beam;
    public Camera fpCam;
    public Transform attackPoint;
    public Light beamBlastLight;


    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = beam.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false; // start hidden
    }

    private void Start()
    {
        calcLogic = FindFirstObjectByType<CalcLogic>();
    }

    public void ShootBeam()
    {
        //make sure beam is visible
        lineRenderer.enabled = true;

        Vector3 startPoint = attackPoint.position;

        //ray from mouse
        Ray ray = fpCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 endPoint;

        if (Physics.Raycast(ray, out hit))
        {
            endPoint = hit.point;

            // (optional) do something with hit
            // Debug.Log("Hit: " + hit.collider.name);
        }
        else
        {
            //fallback forward
            endPoint = ray.origin + ray.direction * 100f;
        }

        //set positions
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);

        //restart beam timer
        StopAllCoroutines();
        StartCoroutine(ShowBeam(0.1f));
    }

    private IEnumerator ShowBeam(float duration)
    {
        yield return new WaitForSeconds(duration);
        lineRenderer.enabled = false;
    }
}
using UnityEngine;
using UnityEngine.Animations;

public class DetectEnemy : MonoBehaviour
{
    public void RayDestroy()
    {
        //set ray coordinates
        Ray ray = CalibrateRayCast();

        //ray hits object && check object has enemy tag
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("enemy"))
        {
            Destroy(hit.collider.gameObject); //destroy enemy
        }
    }

    public Ray CalibrateRayCast()
    {
        //set ray coordinates
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}

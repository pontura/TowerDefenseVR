using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hits;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray, 100.0F);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];

                if (hit.transform.tag == "ground")
                {
                    Events.OnAddDefenseZone(hit.point);
                }
            }
        } else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit[] hits;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray, 100.0F);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];

                if (hit.transform.tag == "ground")
                {
					//Events.OnLeftTriggerRelease(hit.point);
                }
            }
        }
    }
}
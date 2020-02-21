using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    [SerializeField] private Description description;
    int layermask = 1 << 8;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, layermask);

            if (hit.transform.GetComponent<Object>())
            {
                description.AssignBot(hit.transform.GetComponent<Object>());
                description.gameObject.SetActive(true);
                return;
            }

            description.gameObject.SetActive(false);
        }
    }
}

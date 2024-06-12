using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private GameObject sword;
    private Dray dray;
    // Start is called before the first frame update
    void Start()
    {
        Transform swordT = transform.Find("Sword");
        if (swordT == null)
        {
            Debug.LogError("Could not find Sword child of SwordController.");
            return;
        }
        sword = swordT.gameObject;

        dray = GetComponentInParent<Dray>();
        if (dray == null)
        {
            Debug.LogError("Could not find parent component Dray.");
            return;
        }

        sword.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90 * dray.facing);
        sword.SetActive(dray.mode == Dray.eMode.attack);
    }
}

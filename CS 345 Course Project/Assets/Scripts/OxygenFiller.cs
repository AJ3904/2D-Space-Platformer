using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenFiller : MonoBehaviour
{
    private float maxRefill = 100f;
    private float fillAmount = 10f;
    [SerializeField]
    private OxygenBar oxygenBar;
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            InvokeRepeating("fillOxygen", 1f, 1f);
        }
    }

    void fillOxygen()
    {
        if(maxRefill > 0)
        {
            oxygenBar.currentOxygen += fillAmount;
            maxRefill -= fillAmount;
        }
    }
}

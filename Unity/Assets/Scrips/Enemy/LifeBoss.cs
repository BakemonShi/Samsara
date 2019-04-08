using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBoss : MonoBehaviour
{
    private YakuzaBoss yakuzaBoss;
    public Image imageHeal;
    // Start is called before the first frame update
    void Start()
    {
        yakuzaBoss = GameObject.FindGameObjectWithTag("YakuzaBoss").GetComponent<YakuzaBoss>();
        imageHeal.fillAmount = yakuzaBoss.life/100;

    }

    // Update is called once per frame
    void Update()
    {
        imageHeal.fillAmount = yakuzaBoss.life / 100;

    }
}

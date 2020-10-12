using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    float timer;
    SpriteRenderer medkit;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        medkit = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= Constant.MEDKIT_TIMER)
            Destroy(gameObject);
        if (timer >= Constant.MEDKIT_TIMER - 5)
            medkit.color = new Color(1, 0.5f, 0.5f, 0.5f);
    }
}

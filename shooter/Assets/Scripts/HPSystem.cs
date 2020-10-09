using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPSystem : MonoBehaviour
{
    int HP;

    //Debug
    public TextMeshProUGUI HPText;

    // Start is called before the first frame update
    void Start()
    {
        HP = Functions.MAX_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDead())
            Debug.Log("Game Over");
        //game end

        if (HP > Functions.MAX_HP)
            HP = Functions.MAX_HP;

        //Debug
        if (Input.GetKeyDown("space"))
            removeHP();
        if (Input.GetKeyDown("j"))
            addHP();
        HPText.text = showHP().ToString();
    }

    public void removeHP()
    {
        HP--;
    }

    public void addHP()
    {
        HP++;
    }

    bool playerDead()
    {
        if (HP <= 0)
            return true;
        else
            return false;
    }

    public int showHP()
    {
        return HP;
    }
}

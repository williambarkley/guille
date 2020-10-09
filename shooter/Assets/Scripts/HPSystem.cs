using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPSystem : MonoBehaviour
{
    int HP;

    //Debug
    public TextMeshProUGUI HPText;

    void Start()
    {
        //We initialize values
        HP = Constant.MAX_HP;
    }

    void Update()
    {
        //End game at player death
        if (playerDead())
            Debug.Log("Game Over");
        //game end

        //HP cannot go over maximum
        if (HP > Constant.MAX_HP)
            HP = Constant.MAX_HP;

        //Debug
        if (Input.GetKeyDown("space"))
            removeHP();
        if (Input.GetKeyDown("j"))
            addHP();
        HPText.text = HP.ToString();
    }

    public void removeHP()
    {
        HP--;
    }

    public void addHP()
    {
        HP++;
    }

    //If no more lives, returns true
    bool playerDead()
    {
        if (HP <= 0)
            return true;
        else
            return false;
    }
}

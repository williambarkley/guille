using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    const int MAX_HP = 3;
    int HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = MAX_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDead())
            Debug.Log("Game Over");
        //game end

        if (HP > MAX_HP)
            HP = MAX_HP;
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

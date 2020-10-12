using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HPSystem : MonoBehaviour
{
    SpriteRenderer player;
    public bool invulnerable;
    int invulVisuals;
    float timer;

    int HP;

    //Debug
    public TextMeshProUGUI HPText;

    void Start()
    {
        //We initialize values
        HP = Constant.MAX_HP;
        invulnerable = false;
        timer = 0;
        invulVisuals = 0;

        player = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //End game at player death
        if (playerDead())
            SceneManager.LoadScene(Constant.GAMEOVER_SCENE);

        //HP cannot go over maximum
        if (HP > Constant.MAX_HP)
            HP = Constant.MAX_HP;

        HPText.text = HP.ToString();

        if(invulnerable)
        {
            if (timer < Constant.INVULNERABILITY_TIME)
                timer += Time.deltaTime;
            else
            {
                timer = 0;
                invulVisuals = 0;
                invulnerable = false;
            }

            invulVisuals = Mathf.RoundToInt(timer / 0.2f);
            if (invulVisuals % 2 == 0)
                player.color = new Color(1, 1, 1, .3f);
            else
                player.color = new Color(1, 1, 1, 1);

        }
        else
            player.color = new Color(1, 1, 1, 1);
    }

    public void removeHP()
    {
        HP--;
        invulnerable = true;
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

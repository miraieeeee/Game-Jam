using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [Range(1,60)]
    public float Time;
    public bool Exists;
    public float Velocity = 0f;

    public float min, sec;
    public Text timetext;


    public PlayerMovement player;
    public GameObject Boss;

    void Start()
    {
        Exists = false;

        min = 0;
        sec = 0;

        timetext.text = $"{min.ToString()}:{sec.ToString()}";

        StartCoroutine(TimeHandler(sec, min));
        StartCoroutine(BossHandler(Time));
    }

    IEnumerator TimeHandler(float sec, float min)
    {
        while (!player.endgame)
        {
            yield return new WaitForSeconds(1f);

            if (sec < 60)
            {
                sec++;
            }
            else if (sec >= 59) { min++; sec = 0; }

            timetext.text = $"{min.ToString()}:{sec.ToString()}";

            if (min == 10) { SceneManager.LoadScene("start"); }
        }
    }

    IEnumerator BossHandler(float Time) 
    {
        while (!player.endgame)
        {
            yield return new WaitForSeconds(Time);

            if (!Exists)
            {
                Instantiate(Boss, new Vector3(player.spawmLoc.x, player.spawmLoc.y, player.spawmLoc.z), Quaternion.identity);
                Exists = true;
            }

            Velocity = (!player.isDead) ? Velocity + 0.001f : 0.001f;
        }
    }
}
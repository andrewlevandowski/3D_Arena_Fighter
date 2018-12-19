using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour {

    #region Singleton

    public static GameSingleton instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    //global scene variables
    public GameObject player;
    public GameObject win;
    public  GameObject lose;

    public void Iflose()
    {

      lose.SetActive(true);
    }
    public void Ifwin()
    {
        if (enemyAmount == 0)
        {
            win.SetActive(true);

        }
    }

    public bool playerDead = false;
    public int enemyAmount;

}

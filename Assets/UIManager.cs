using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    Enemy enemy;
    Player player;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            if(enemy.currentHealth <= 0)
            {
                Time.timeScale = 0;
            }
        }
        if(player != null)
        {
            if(player.currentHealth <= 0)
            {
                Time.timeScale = 0;
            }
        }
    }
}

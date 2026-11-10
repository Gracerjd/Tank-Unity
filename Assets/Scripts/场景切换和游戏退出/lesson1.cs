using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //切换场景
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Test2");
        }
        //退出游戏
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //编辑模式下没有用
            Application.Quit();
        }
    }
}

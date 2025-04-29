using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    public float forceValue;
    private Rigidbody2D rigidbody2D = null;
    public scoreManager scoremanager;

    // Update is called once per frame
    void Update()
    {
        Vector2 force2D = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            force2D.y += forceValue;
        }
        if (Input.GetKey(KeyCode.S))
        {
            force2D.y -= forceValue;
        }
        if (Input.GetKey(KeyCode.A))
        {
            force2D.x -= forceValue;
        }
        if (Input.GetKey(KeyCode.D))
        {
            force2D.x += forceValue;
        }

        rigidbody2D.AddForce(force2D);

        // 新增：按下 Esc 退出應用程式
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // 在編輯器中停止播放
        #else
                Application.Quit(); // Build 出來的執行檔會關閉程式
        #endif
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        scoremanager.AddScore(100);
        other.gameObject.SetActive(false);
    }
}

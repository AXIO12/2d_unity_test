using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    //音量　0.0f～1.0f
    [Range(0.0f, 1.0f)]
    public float bgm_volume = 0.5f;
    [Range(0.0f, 1.0f)]
    public float se_volume = 0.5f;

    
    void Start()
    {
        //BGMロード
        Sound.LoadBgm("bgm", "ユビ");
        Sound.LoadBgm("aaa", "Heavy_Slap");
        //SEロード
        Sound.LoadSe("jump", "Shot");
        Sound.LoadSe("walk", "Walk");
        Sound.LoadSe("ref", "reflection");
        
    }

    private void Update()
    {

        //BGM再生
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Sound.PlayBgm("aaa");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Sound.PlayBgm("bgm");
        }


        //音量変更
        Sound.ChangeVolumeBgm(bgm_volume);
        Sound.ChangeVolumeSe(se_volume);
    }


    void onDestroy()
    {
        //BGM停止
        Sound.StopBgm();
        Debug.Log("stop_bgm");
    }
}
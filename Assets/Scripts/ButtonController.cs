using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    public float clickCooldown = 5f; // 设置点击冷却时间
    
    private GameData gameData;
    

    // Start is called before the first frame update
    void Start()
    {
        gameData = PublicTool.GetGameData();
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void GetButtonPostion()
    {
        Shoot();
        StartCoroutine(DisableButtonTemporarily());
       
    }

    private IEnumerator DisableButtonTemporarily()
    {
        GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(3); // 等待3秒
        GetComponent<Button>().interactable = true;
        
    }


    private void Shoot()
    {
        gameData.ButtonPostion = transform.position;
        EventCenter.Instance.EventTrigger("ClickButton", 1);
        Debug.Log("click button");
    }

   
}

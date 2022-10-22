using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Manager : MonoBehaviour
{
    [SerializeField] private HealthBar _Healthbar;
    [SerializeField] private Player _Player;
    [SerializeField] private Button[] _Healthbuttons;
    [SerializeField] private GameObject blade1;
    [SerializeField] private GameObject blade2;
    [SerializeField] private GameObject blade3;
    [SerializeField] private GameObject blade4;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        _Healthbuttons = new Button [4];
        for(int i = 1; i> 4; i++)
        {
            _Healthbuttons[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Resume()
    {

        GameObject.FindWithTag("LevelUpMenu").SetActive(false);
        Time.timeScale = 1f;
    }
    public void HealthButtonPressed()

    {
        Button currentb = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        currentb.interactable = false;
        currentb.animator.SetBool("IsDisabled", true);
        globalVarables.playerMaxHealth += 20;
       
        _Healthbar.UpdateData();
        _Player.heal(10);



    }
    public void SwordButtonPressed()
    {
        Button currentb = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        currentb.interactable = false;
        if (!blade1.active)

        {
            blade1.SetActive(true);
        }
        else if (!blade2.active)
        {
            blade2.SetActive(true);
        }
        else if (!blade3.active)
        {
            blade1.transform.localEulerAngles = new Vector3(0, 0, -120);
            blade1.transform.localPosition = new Vector3(0.7f, -0.4f, 0);
            
            blade2.transform.localEulerAngles = new Vector3(0, 0, 120);
            blade2.transform.localPosition = new Vector3(-0.7f, -0.4f, 0);
            blade3.SetActive(true);
        }
        else
        {
            blade1.transform.localEulerAngles = new Vector3(0, 0, -90);
            blade1.transform.localPosition = new Vector3(0.8f, 0, 0);

            blade2.transform.localEulerAngles = new Vector3(0, 0, 90);
            blade2.transform.localPosition = new Vector3(-0.8f, 0, 0);

            blade4.SetActive(true);
        }
    }
}
   

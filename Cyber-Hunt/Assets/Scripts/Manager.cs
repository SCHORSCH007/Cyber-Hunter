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
}
   

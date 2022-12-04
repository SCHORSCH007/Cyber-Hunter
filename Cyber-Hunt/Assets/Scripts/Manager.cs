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
    [SerializeField] private GameObject blade1;
    [SerializeField] private GameObject blade2;
    [SerializeField] private GameObject blade3;
    [SerializeField] private GameObject blade4;

    [SerializeField] private GameObject Shield;

    private SpriteRenderer sp1;
    private SpriteRenderer sp2;
    private SpriteRenderer sp3;
    private SpriteRenderer sp4;


    // Start is called before the first frame update
    void Start()
    {
        sp1 = blade1.GetComponent<SpriteRenderer>();
        sp2 = blade2.GetComponent<SpriteRenderer>();
        sp3 = blade3.GetComponent<SpriteRenderer>();
        sp4 = blade4.GetComponent<SpriteRenderer>();

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
    public void SwordButtonActivated(int bladenumber)
    {
        switch (bladenumber)
        {

            case 1:
                blade1.SetActive(true);
                break;

            case 2:
                blade2.SetActive(true);
                break;

            case 3:
                blade1.transform.localEulerAngles = new Vector3(0, 0, -120);
                blade1.transform.localPosition = new Vector3(0.7f, -0.4f, 0);
                blade2.transform.localEulerAngles = new Vector3(0, 0, 120);
                blade2.transform.localPosition = new Vector3(-0.7f, -0.4f, 0);
                blade3.SetActive(true);
                break;

            case 4:
                blade1.transform.localEulerAngles = new Vector3(0, 0, -90);
                blade1.transform.localPosition = new Vector3(0.8f, 0, 0);
                blade2.transform.localEulerAngles = new Vector3(0, 0, 90);
                blade2.transform.localPosition = new Vector3(-0.8f, 0, 0);
                blade4.SetActive(true);
                break;

            default: break;
        }
    }
    public void SwordDamageButtonPressed()
    {
        Button currentb = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        currentb.interactable = false;
       
        sp1.color = new Color(255, 0, 151);
        sp2.color = new Color(255, 0, 151);
        sp3.color = new Color(255, 0, 151);
        sp4.color = new Color(255, 0, 151);


    }
    public void ShieldEnabled()
    {
        Shield.SetActive(true);
    }
    public void BeginnShieldReset(int ResetTime)
    {
        StartCoroutine(ShieldReset(ResetTime));
    }

    IEnumerator ShieldReset(int Time)
    {
        yield return new WaitForSeconds(Time);
        Shield.SetActive(true);
    }
}
   

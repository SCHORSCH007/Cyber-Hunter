using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimeSurvived;
    [SerializeField] private TextMeshProUGUI kills;

    
    private float timer = 0.0f;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        kills.SetText(globalVarables.kills.ToString());
        timer = Time.timeSinceLevelLoad;

        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        TimeSurvived.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }

}

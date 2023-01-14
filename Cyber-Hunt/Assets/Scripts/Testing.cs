using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private UI_SkillTree uiSkillTree;

    private void Start()
    {
        uiSkillTree.SetPlayerSkills(player.GetPlayerSkills());
    }
}

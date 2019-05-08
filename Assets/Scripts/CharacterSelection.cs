using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CharacterSelection : MonoBehaviour {

    private GameObject[] tagTeamList;
    private int index;
    public GameObject player1;
    public GameObject player2;
    //private CinemachineVirtualCamera vcam;
   // public Transform tFollowTarget;
    //public GameObject tPlayer;

    private void Start()
    {
       // var vcam = GetComponent<CinemachineVirtualCamera>();
        tagTeamList = new GameObject[transform.childCount];
        // fill array
        for (int i = 0; i < transform.childCount; i++)
        
            tagTeamList[i] = transform.GetChild(i).gameObject;
        // toggle off renderer
        foreach (GameObject go in tagTeamList)
        
        go.SetActive(false);

        if (tagTeamList[0])
            tagTeamList[0].SetActive(true);

        
    }
    public void TagTeamButton()
    {
        // Toggle off current player
        tagTeamList[index].SetActive(false);

    

        index--;
        if (index < 0)
            index = tagTeamList.Length - 1;
        if (index != 1)
           // player2.transform.position = player1.transform.position;
        player1.transform.position = player2.transform.position;
        if (index != 0)
          //  player1.transform.position = player2.transform.position;
        player2.transform.position = player1.transform.position;

      

        // Toggle on new player
        tagTeamList[index].SetActive(true);

       // tFollowTarget = tPlayer.transform;
      //  vcam.Follow = tFollowTarget;

    }
}

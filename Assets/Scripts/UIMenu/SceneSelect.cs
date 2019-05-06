using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour {

    public void selectScene()
    { switch (this.gameObject.name)
        {
            case "LevelSelectButton":
                SceneManager.LoadScene("LevelSelect");
                break;
            case "TutorialButton":
                SceneManager.LoadScene("SampleScene");
                break;
            case "Stage1Button":
                SceneManager.LoadScene("Stage1");
                break;
            case "Stage1-1Button":
                SceneManager.LoadScene("Stage1-1");
                break;
        }

    }
}

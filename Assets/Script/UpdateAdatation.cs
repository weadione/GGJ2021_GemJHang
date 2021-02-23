using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateAdatation : MonoBehaviour
{
    public Slider animalSlider, machineSlider;

    private void Start()
    {

        StartCoroutine(updateAnimal());
        StartCoroutine(updateMachine());

        GameManager.Instance.animalPartsAdaptation += PlayerState.Instance.animalAdaptationTmp;
        GameManager.Instance.machinePartsAdaptation += PlayerState.Instance.machineAdaptationTmp;
        GameManager.Instance.AdaptationSave();
    
        GameManager.Instance.ResetSave();
        GameManager.Instance.Load();
    }

    private IEnumerator updateAnimal()
    {
        float PartsAdaptation = GameManager.Instance.animalPartsAdaptation;
        float AdaptationTmp = PlayerState.Instance.animalAdaptationTmp;
        float difference = AdaptationTmp / 30f;

        animalSlider.value = PartsAdaptation;
        Debug.Log(PartsAdaptation);
        Debug.Log(AdaptationTmp);
        Debug.Log(difference);
        for(int i=0;i<30;i++)
        {
            Debug.Log("동물 " + i + " 번째 " + animalSlider.value);
            animalSlider.value += difference;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator updateMachine()
    {
        float PartsAdaptation = GameManager.Instance.machinePartsAdaptation;
        float AdaptationTmp = PlayerState.Instance.machineAdaptationTmp;
        float difference = AdaptationTmp / 30f;

        machineSlider.value = PartsAdaptation;

        for (int i = 0; i < 30; i++)
        {
            machineSlider.value += difference;
            yield return new WaitForSeconds(0.1f);
        }
    }


    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}

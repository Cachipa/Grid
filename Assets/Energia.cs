using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energia : MonoBehaviour
{
    public Slider energia;
    private int MaxEnergia = 100;
    private int EnergiaAtual;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    public static Energia instance;

    public void Awake(){
        instance = this;
    }

    void Start()
    {
        EnergiaAtual = MaxEnergia;
        energia.maxValue = MaxEnergia;
        energia.value = MaxEnergia;
    }

    public void UseEnergia(int amount){
        if(EnergiaAtual - amount >= 0){
            EnergiaAtual -= amount;
            energia.value = EnergiaAtual;

            StartCoroutine(RegenEnergia());
        }
        else{
            Debug.Log("Sem Energia");
        }
    }

    private IEnumerator RegenEnergia(){
        yield return new WaitForSeconds(2);

        while(EnergiaAtual < MaxEnergia){
            EnergiaAtual += MaxEnergia/100;
            energia.value = EnergiaAtual;
            yield return regenTick;

        }

    }

}

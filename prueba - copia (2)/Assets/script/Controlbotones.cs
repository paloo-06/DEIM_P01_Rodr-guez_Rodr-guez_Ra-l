using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
public class Controlbotones : MonoBehaviour
{

    public RectTransform botonjugar;
    public Ease botonjugarease;
    public Image fadeScreen;
    
    private void Start()
    {
    fadeScreen.DOFade(0, 2).OnComplete(() => {
            //esto hace que duplique el botonde jugar el doble durane dos segundo,doble porque es dos y dos segundos porque es dos
            botonjugar.DOScale(2, 2).SetEase(botonjugarease).OnComplete(() =>
            {
                //el paenetesis es que estaqmos indicando que no tiene parametro     

                //hace que el boton comience a brivar
                botonjugar.DOShakePosition(1, 9, vibrato: 100).SetLoops(-1);
            });
        });
    }    

    public void cargarescena()
    {
       

       //en el cambio de escena hace un face empezando de verse ,a verse en negro 
       fadeScreen.DOFade(1, 2).OnComplete(() =>
        {
            SceneManager.LoadScene("Prueba");

        });
       

    }   }

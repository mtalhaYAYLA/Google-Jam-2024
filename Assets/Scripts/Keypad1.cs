using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject gateDoor;
    private Animator anim;
    
  

    public Text textOB;
    public string answer = "12345";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    
   


    void Start()
    {
        keypadOB.SetActive(false);
       
       


    }


    public void Number(int number)
    {
        textOB.text += number.ToString();
        button.Play();
    }

    public void Execute()
    {
        if (textOB.text == answer)
        {
            correct.Play();
            textOB.text = "Doğru";
            anim = gateDoor.GetComponent<Animator>();
            anim.Play("Open");
            keypadOB.SetActive(false);
            player.GetComponent<CharacterController>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            wrong.Play();
            textOB.text = "Yanlış";
        }


    }

    public void Clear()
    {
        {
            textOB.text = "";
            button.Play();
        }
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        player.GetComponent<CharacterController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        
    }

   


    public void Update()
    {
        if (textOB.text == "Right")
        {
            
            Debug.Log("its open");

            
        }

        if (keypadOB.activeInHierarchy)
        {
            
            player.GetComponent<CharacterController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            
        }

        
        

        

    }


}

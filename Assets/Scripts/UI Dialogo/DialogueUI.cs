using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialogo;
using TMPro;
using UnityEngine.UI;

namespace UI
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField]PlayerConversant playerConversant;
        [SerializeField] TextMeshProUGUI AIText;
        [SerializeField] Button nextButton;

        private void Awake()
        {
            //EventForGame.instance.activarDialogo.AddListener(UpdateUI);
            //playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
            //playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>();
            nextButton.onClick.AddListener(Next);
            //UpdateUI();
        }

        void Start()
        {
            //playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
            //playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>();
            //nextButton.onClick.AddListener(Next);
            
            
        }

        private void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Comma))
            {
                if(playerConversant.HasNext())
                {
                    Next();
                }
                
            }
        }

        void Next()
        {
            playerConversant.Next();
            UpdateUI();
        }

        public void UpdateUI()
        {
            AIText.text = playerConversant.GetText();
            nextButton.gameObject.SetActive(playerConversant.HasNext());
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelefoneInteract : Interactable
{
    public bool hasKey;
    public Diario diary;   
    public GameObject atualizacaoSemChave;
    public GameObject atualizacaoComChave;
    public DialogueBase dialogo;
    private bool coroutineStart = true;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip telefoneCaindo;

    private int dialogoNumeracao = 1;

    InputManager inputManager;

    [SerializeField]
    private GameObject monitor;
    [SerializeField]
    private GameObject telaMonitor;
    [SerializeField]
    private GameObject administracaoReminder;

    private VolumeManager volumeManager;
    [SerializeField]
    private float velocidadeTransicao;
    [SerializeField]
    private GameObject puzzleNormal;
    [SerializeField]
    private GameObject puzzleSombra;

    [SerializeField]
    GameObject doorToUnlock;

    [SerializeField]
    Animator animator;
    [SerializeField]
    string boolName;

    bool once;

    private void Start()
    {
        inputManager = InputManager.Instance;
        audioSource = GetComponent<AudioSource>();
        volumeManager = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
    }

    private void Update()
    {
        if (inputManager.NextDialogue() && coroutineStart == false) dialogoNumeracao += 1;
    }
    public override void Interact()
    {
        if (!hasKey && !once)
        {
            diary.FillPage(atualizacaoSemChave);
            once = true;
    
        }

        else if(hasKey)
        {
            if (coroutineStart) StartCoroutine("EventoTelefone");
        }
    }


    IEnumerator EventoTelefone()
    {
        coroutineStart = false;
        audioSource.Stop();
        audioSource.loop = false;
        DialogueManager.instance.EnqueueDialogue(dialogo);
        puzzleNormal.SetActive(true);
        puzzleSombra.SetActive(false);
        volumeManager.TransicaoOut(velocidadeTransicao);
        while (dialogoNumeracao < 5)
        {
            yield return null;
        }
        audioSource.volume = 0.3f;
        audioSource.clip = telefoneCaindo;
        audioSource.Play();
        yield return new WaitForSeconds(2.7f);
        audioSource.Stop();
        while (dialogoNumeracao < 6)
        {
            yield return null;
        }
        Destroy(doorToUnlock.GetComponent<DialogueInteract>());
        doorToUnlock.AddComponent<AnimationInteract>();
        animator = doorToUnlock.GetComponent<Animator>();
        doorToUnlock.GetComponent<AnimationInteract>().animator = this.animator;
        doorToUnlock.GetComponent<AnimationInteract>().boolAnimationName = boolName;
        monitor.GetComponent<BoxCollider>().enabled = true;
        monitor.GetComponentInChildren<Light>().enabled = false;
        administracaoReminder.GetComponent<BoxCollider>().enabled = true;
        telaMonitor.SetActive(false);
        diary.FillPage(atualizacaoComChave);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{

    private Animator animator;

    [SerializeField] private float summonCooldown;

    [SerializeField] private float dashCoolDown;

    private float summonWait;

    private float dashWait;

    public GameObject SceneTransition;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        summonWait = summonCooldown;
        dashWait = dashCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= summonWait)
       {
        summonWait = Time.time + summonCooldown;
        animator.SetTrigger("summon");
       }

       if (Time.time >= dashWait)
       {
        dashWait = Time.time + dashCoolDown;
        animator.SetBool("Dash", true);
       }
    }

    void SpawnNextSceneTransition() {
        SceneTransition.SetActive(true);
    }
}

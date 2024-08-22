using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    [SerializeField] AnimationCurve dodgeCurve;
    CharacterMovement characterMovement;
    Animator anim;
    CharacterController characterController;
    bool isDodging;
    float dodgeTimer;

    // Start is called before the first frame update
    void Start()
    {
	characterMovement = GetComponent<CharacterMovement>();
	anim = GetComponent<Animator>();
	characterController = GetComponent<CharacterController>();
        Keyframe dodge_lastFrame = dodgeCurve[dodgeCurve.keys.Length - 1];
	dodgeTimer = dodge_lastFrame.time;
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.LeftControl) && !isDodging)
    	{
            if(characterMovement.moveDirection.magnitude != 0)
            StartCoroutine(Dodging());
    	} 
    }

    IEnumerator Dodging(){

	float timer = 0;
	anim.SetTrigger("Dodge");
	while(timer < dodgeTimer){
	    float speed = dodgeCurve.Evaluate(timer);
	    Vector3 dir = (transform.forward * speed) + (Vector3.up * characterMovement.jumpVelocity.y);
	    characterController.Move(dir * Time.deltaTime);
	    timer += Time.deltaTime;
	    yield return null;
	}

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EightDirectionalSpriteSystem
{
    public class AnimationManager : MonoBehaviour
    {
        //[12/27/21] [Monday, 10:54 PM]

        //This is the AnimationManager script, which is essentially a neutered version of an EDSS script that
        //controls when a particular animation is playing using the Eight-Direction Sprite System. In this
        //script, it checks of the actorBillboard (the gameObject the script is attached to) is null. If not,
        //then it will play the corresponding animation set by the Public ActorAnimation segment. There's 
        //really not much else so say since it's really just a watered-down version of another Asset's 
        //script, so enjoy!


        public ActorBillboard actorBillboard;

        public ActorAnimation Animation;

        private Transform myTransform;
        //private ActorAnimation currentAnimation = null;


        void Awake()
        {
            myTransform = GetComponent<Transform>();
        }

        private void Start()
        {
            if (actorBillboard != null)
            {
                actorBillboard.PlayAnimation(Animation);
            }
        }

        void Update()
        {
            if (actorBillboard != null)
            {
                actorBillboard.SetActorForwardVector(myTransform.forward);
            }

        }
    }
}

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace EightDirectionalSpriteSystem
{
    [ExecuteInEditMode]
    public class DemoActor : MonoBehaviour
    {
        public enum State { NONE, IDLE, WALKING, FLEE, STEPBACK, SHOOT, PAIN, DIE};

        public ActorBillboard actorBillboard;

        public ActorAnimation idleAnim;
        public ActorAnimation walkAnim;
        public ActorAnimation fleeAnim;
        public ActorAnimation stepbackAnim;
        public ActorAnimation shootAnim;
        public ActorAnimation painAnim;
        public ActorAnimation dieAnim;


        private Transform myTransform;
        private ActorAnimation currentAnimation = null;
        private State currentState = State.NONE;

        void Awake()
        {
            myTransform = GetComponent<Transform>();
        }

        void Start()
        {
            SetCurrentState(State.IDLE);
        }

        private void OnEnable()
        {
            SetCurrentState(State.IDLE);
        }

        private void OnValidate()
        {
            if (actorBillboard != null && actorBillboard.CurrentAnimation == null)
                SetCurrentState(currentState);
        }

        void Update()
        {
            if (actorBillboard != null)
            {
                actorBillboard.SetActorForwardVector(myTransform.forward);
            }
           
        }

        private void SetCurrentState(State newState)
        {
            currentState = newState;
            switch (currentState)
            {

                case State.WALKING:
                    currentAnimation = walkAnim;
                    break;

                case State.FLEE:
                    currentAnimation = fleeAnim;
                    break;

                case State.STEPBACK:
                    currentAnimation = stepbackAnim;
                    break;

                case State.SHOOT:
                    currentAnimation = shootAnim;
                    break;

                case State.PAIN:
                    currentAnimation = painAnim;
                    break;

                case State.DIE:
                    currentAnimation = dieAnim;
                    break;

                default:
                    currentAnimation = idleAnim;
                    break;
            }

            if (actorBillboard != null)
            {
                actorBillboard.PlayAnimation(currentAnimation);
            }
        }

    }
}

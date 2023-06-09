using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickController : MonoBehaviour
{
    public static PickController instance; 

    public GameObject pickHolder;

    public GameObject pick;

    public PickTrigger pickTrigger;

    public AudioSource pickSource;

    public SpriteRenderer pickSpriteRenderer;

    public List<GuitarString> strings = new List<GuitarString>();

    public int startStringIndex;

    private int currentStringIndex;

    public float moveTime;

    public float alternateTime;

    public AnimationCurve moveCurve;

    public AnimationCurve rotateCurve;

    public UnityEvent moveUp = new UnityEvent();

    public UnityEvent moveDown = new UnityEvent();

    public GameObject shield;
    private void Start()
    {
        instance = this;

        SetCurrentGuitarString(startStringIndex);

        pickTrigger.triggerEntered.AddListener(PickOnTriggerEnter);
    }
    private void SetCurrentGuitarString(int index)
    {
        currentStringIndex = index;
    }
    private void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(true);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Move(false);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Alternate();
            }
        }    
    }
    bool isMoving;
    public void Move(bool isDirectionUp)
    {
        if (isDirectionUp)
        {
            if (currentStringIndex > 0)
            {
                moveUp.Invoke();

                StartCoroutine(MoveCoroutine(1));                 
            }
        }
        else
        {
            if (currentStringIndex < strings.Count - 1)
            {
                moveDown.Invoke();

                StartCoroutine(MoveCoroutine(-1));                   
            }
        }
    }
    private IEnumerator MoveCoroutine(int direction)
    {
        isMoving = true;

        int targetStringIndex = currentStringIndex - direction;

        LeanTween.move(pickHolder, new Vector2(pickHolder.transform.position.x, strings[targetStringIndex].transform.position.y), moveTime).setEase(moveCurve);

        LeanTween.rotateAroundLocal(pick, Vector3.forward, 360f, moveTime).setEase(rotateCurve);

        yield return new WaitForSeconds(moveTime);

        currentStringIndex = targetStringIndex;

        isMoving = false;
    }  
    public void Alternate()
    {
        StartCoroutine(AlternateCoroutine());
    }
    bool isPickDown = false;
    public IEnumerator AlternateCoroutine()
    {
        isMoving = true;

        LeanTween.moveLocalY(pick, pick.transform.localPosition.y + ((2 * pick.transform.localPosition.y) * -1), alternateTime).setEaseLinear();

        isPickDown = !isPickDown;

        if (isPickDown)
        {
            LeanTween.rotateAroundLocal(pick, Vector3.forward, 120, alternateTime).setEaseLinear();
        }
        else
        {
            LeanTween.rotateAroundLocal(pick, Vector3.forward, -120, alternateTime).setEaseLinear();
        }
        
        yield return new WaitForSeconds(alternateTime);

        isMoving = false;
    }

    public Detach detach;
    public void PickString()
    {
        if (detach.abilityActivated)
        {
            detach.DetachAll();
        }

        if (pickTrigger.currentEntity != null)
        {
            if(pickTrigger.currentEntity is IPickable)
            {
                IPickable pickable = (IPickable)pickTrigger.currentEntity;

                pickable.Pick();
            }

            strings[currentStringIndex].PlayFret();
        }
        else
        {
            strings[currentStringIndex].PlayOpen();
        }     
    }
    public void PickOnTriggerEnter()
    {
        if (pickTrigger.currentEntity is not GoodNote && pickTrigger.currentEntity is not Chord)
        {
            pickTrigger.currentEntity.Interact();

            pickSource.Play();
        }
    }
    public GuitarString GetCurrentGuitarString()
    {
        return strings[currentStringIndex];
    }
    public void ImmunityEffectOn()
    {
        shield.SetActive(true);

    }
    public void ImmunityEffectOff()
    { 
        shield.SetActive(false);
    }
}

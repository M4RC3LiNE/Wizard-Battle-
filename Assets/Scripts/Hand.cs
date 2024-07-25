using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public List<Sprite> idleFrame = new List<Sprite>();
    public Sprite shootFrame;
    private int selected_idleFrame = 0;
    private Coroutine coroutine;
    private bool coRunning = false;
    private float input;

    void Update()
    {
        var img = GetComponent<UnityEngine.UI.Image>();
        if (img != null)
        {
            if (Input.GetMouseButton(0))
            {
                img.sprite = shootFrame;
            }
            else{
                img.sprite = idleFrame[selected_idleFrame];
            }
        }
        var input = Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Horizontal");
        if (input > 0 )
        {
            if (!coRunning)
            {
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                coroutine = StartCoroutine(CycleIdle());
            }
        }
    }

    IEnumerator CycleIdle()
    {
        coRunning = true;
        while (input > 0)
        {
            if (selected_idleFrame < idleFrame.Count - 1)
            {
                selected_idleFrame += 1;
            }else{
                selected_idleFrame = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
        coRunning = false;
    }

    Vector2 startPos;

    void Start()
    {
        startPos = this.transform.localPosition;
        StartCoroutine(UpDownHand());
    }

    IEnumerator UpDownHand()
    {
        while (true)
        {
            if (this.transform.localPosition.y > startPos.y)
            {
                this.transform.localPosition -= new Vector3(0, 7, 0);
            }
            else{
                this.transform.localPosition += new Vector3(0, 7, 0);
            }
            yield return new WaitForSeconds(1);
        }
    }
}

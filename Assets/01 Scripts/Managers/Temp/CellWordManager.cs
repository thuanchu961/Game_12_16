using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellWordManager : Singleton<CellWordManager>, IObserver
{
    Subject subject;
    ISetActiveCell setActiveCell;
    IMoveToTarget moveToTarget;
    //IFadeInAlphabet fadeinAlphabet;
    private void Awake()
    {
        subject = FindObjectOfType<MainCarController>();
        subject.AddObserver(this);
    }
    private void Start()
    {    
        setActiveCell = GetComponent<ISetActiveCell>();
        moveToTarget = GetComponent<IMoveToTarget>();
        //fadeinAlphabet = GetComponent<IFadeInAlphabet>();
    }
    public void OnNotify(float value)
    {
        setActiveCell.SetActiveCell();
    }
    public void FadeinCellWord()
    {
        moveToTarget.MoveToTarget(0.5f, this.transform.position, new Vector3(0, 0, 0));
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        //fadeinAlphabet.FadeInAlphabet();
    }
    private void OnDestroy()
    {
        subject.RemoveObserver(this);
    }
}

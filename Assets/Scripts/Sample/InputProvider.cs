using System;
using UniRx;
using UnityEngine;
using Utility;

public class InputProvider : SingletonMonoBehaviour<InputProvider>
{
    private Subject<Unit> _onClickSubject = new Subject<Unit>();
    public IObservable<Unit> OnClickAsObservable => _onClickSubject.ThrottleFirstFrame(3);

    public override void Awake()
    {
        _isSceneSingleton = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _onClickSubject.OnNext(Unit.Default);
        }
    }
}

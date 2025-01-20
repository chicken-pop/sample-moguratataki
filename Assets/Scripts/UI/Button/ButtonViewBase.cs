using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonViewBase : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    public Button Button => _button;

    public IObservable<Unit> OnClickAsObservable() => _button.OnClickAsObservable();
}

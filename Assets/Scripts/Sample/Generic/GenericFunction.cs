using UnityEngine;

public class GenericFunction : MonoBehaviour
{
    private int num01;
    private int num02;

    private bool a;

    private void Start()
    {
        IntCalculation(num01, num02);

        FloatCalculation(num01, num02);

        CalculationA(num01, num02);

        CalculationA(a, a);�@// �G���[�ł�
    }

    public int IntCalculation(int a, int b)
    {
        return a + b;
    }

    public float FloatCalculation(float a, float b)
    {
        return a + b;
    }

    /*
    public T ErrorCalculation<T>(T a, T b)
    {
        return a + b; // �^T���K�������v�Z�ł�����̂Ƃ͌���Ȃ�����
    }
    */

    // �W�F�l���b�N�^������g�p
    // struct�i�l�^�A�Ⴆ�΁Aint,float,bool,DateTime�j�̐���ɕύX
    // dynamic�^�i�R���p�C�����ł͂Ȃ����s���Ɍ^�����肳��铮�I�^�t���j�ɕϊ��A�������^���S���������邽�߁A���s���ɃG���[�̉\������
    //�@�⑫�FC#�͐ÓI�^�t���̌���ŁA�ϐ��̌^�̓R���p�C�����Ɍ���
    public T CalculationA<T>(T a, T b) where T : struct
    {
        dynamic da = a;
        dynamic db = b;
        return (T)(da + db);
    }

    /*
    // c#11,.NET 7 �ȍ~��INumber<T>���g�p�\
    // Unity2023.1�ȍ~����.NET 7�����p�\�炵���̂ō���ł̓G���[���ł�
    public T CalculationB<T>(T a, T b) where T : INumber<T>
    {
        return a + b;
    }
    */
}

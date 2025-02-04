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

        CalculationA(a, a);　// エラーでる
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
        return a + b; // 型Tが必ずしも計算できるものとは限らないから
    }
    */

    // ジェネリック型制約を使用
    // struct（値型、例えば、int,float,bool,DateTime）の制約に変更
    // dynamic型（コンパイル時ではなく実行時に型が決定される動的型付け）に変換、ただし型安全性が失われるため、実行時にエラーの可能性あり
    //　補足：C#は静的型付けの言語で、変数の型はコンパイル時に決定
    public T CalculationA<T>(T a, T b) where T : struct
    {
        dynamic da = a;
        dynamic db = b;
        return (T)(da + db);
    }

    /*
    // c#11,.NET 7 以降でINumber<T>が使用可能
    // Unity2023.1以降から.NET 7が利用可能らしいので今回ではエラーがでる
    public T CalculationB<T>(T a, T b) where T : INumber<T>
    {
        return a + b;
    }
    */
}

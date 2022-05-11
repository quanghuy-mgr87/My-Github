void Swap(int a, int b)
{
    int tg = a;
    a = b;
    b = tg;
}

void Swap2(ref int a, ref int b)
{
    int tg = a;
    a = b;
    b = tg;
}

int a = 2;
int b = 3;

Console.WriteLine("Cap so ban dau:");
Console.WriteLine($"a = {a}, b = {b}");

Console.WriteLine("Dung Swap (truyen tham tri):");
Swap(a, b);
Console.WriteLine($"a = {a}, b = {b}");

Console.WriteLine("Dung Swap2 (truyen tham chieu):");
Swap2(ref a, ref b);
Console.WriteLine($"a = {a}, b = {b}");
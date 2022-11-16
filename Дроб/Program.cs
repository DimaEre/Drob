using System;
using System.Collections.Specialized;
using System.Drawing;

class Drib
{
    public int чисельник;
    public int знаменник;

    public Drib()
    {
    }
    public Drib(int чисельник, int знаменник)
    {
        this.чисельник = чисельник;
        this.знаменник = знаменник;
    }
    public void скорочення()
    {
        bool a = true;
        while (a == true)
        {
            if (чисельник == 0)
            {
                знаменник = 0;
                a = false;
            }
            else if (знаменник != 1)
            {
                if (знаменник % чисельник == 0)
                {
                    знаменник /= чисельник;
                    чисельник = 1;
                }
                else if (чисельник % знаменник == 0)
                {
                    чисельник /= знаменник;
                    знаменник = 1;
                }
                else if (чисельник % 2 == 0 && знаменник % 2 == 0)
                {
                    чисельник /= 2;
                    знаменник /= 2;
                }
                else if (чисельник % 3 == 0 && знаменник % 3 == 0)
                {
                    чисельник /= 3;
                    знаменник /= 3;
                }
                else if (чисельник % 5 == 0 && знаменник % 5 == 0)
                {
                    чисельник /= 5;
                    знаменник /= 5;
                }
                else
                {
                    a = false;
                }
            }
            else a = false;
        }
    }


    public static Drib operator + (Drib drib1, Drib drib2)
    {
        Drib rezult = new Drib();
        rezult.знаменник = drib1.знаменник * drib2.знаменник;
        rezult.чисельник = drib2.знаменник * drib1.чисельник + drib1.знаменник * drib2.чисельник;
        rezult.скорочення();
        return rezult;
    }
    public static Drib operator / (Drib drib1, Drib drib2)
    {
        Drib rezult = new Drib();
        rezult.знаменник = drib1.знаменник * drib2.чисельник;
        rezult.чисельник = drib1.чисельник * drib2.знаменник;
        rezult.скорочення();
        return rezult;
    }
    public static Drib operator - (Drib drib1, Drib drib2)
    {
        Drib rezult = new Drib();
        rezult.знаменник = drib1.знаменник * drib2.знаменник;
        rezult.чисельник = drib2.знаменник * drib1.чисельник - drib1.знаменник * drib2.чисельник;
        rezult.скорочення();
        return rezult;
    }
    public static Drib operator * (Drib drib1, Drib drib2)
    {

        Drib rezult = new Drib();
        rezult.знаменник = drib1.знаменник * drib2.знаменник;
        rezult.чисельник = drib1.чисельник * drib2.чисельник;
        rezult.скорочення();
        return rezult;
    }
}

class Program
{
 
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;

        int a;
        int b;
        Drib[] drib = new Drib[2];
        for (int i = 0; i < drib.Length; i++)
        {
            a = 0;
            b = 0;
            Console.WriteLine("Введіть " + (i + 1) + " дріб\n");
            Console.WriteLine("Введіть чисельник\n");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть знаменник\n");
            while (b ==0) b = Convert.ToInt32(Console.ReadLine());
            drib[i] = new Drib(a,b);
            Console.Clear();
        }

        Drib rezult = new Drib();
        rezult = drib[0] + drib[1];
        Console.WriteLine("додавання: " + rezult.чисельник + " | " + rezult.знаменник);
        rezult = drib[0] - drib[1];
        Console.WriteLine("віднімання: " + rezult.чисельник + " | " + rezult.знаменник);
        rezult = drib[0] / drib[1];
        Console.WriteLine("ділення: " + rezult.чисельник + " | " + rezult.знаменник);
        rezult = drib[0] * drib[1];
        Console.WriteLine("множення: " + rezult.чисельник + " | " + rezult.знаменник);
        return;
    }
}

using System;

class Program
{
    static int i_byte(int x, int n) {
        for (int i = -1; i < n - 1; i++)
        {
            x >>= 1; // сдвигаем биты пока нужный не окажется младшим
        }
        if ((x & 1) == 0) { // сбрасываем все кроме младшего
            return 0; 
        }
        else
        {
            return 1;
        }

    } 
    static void binary_n1(int n)
    {

        if (n < 0)
        {
            int n1 = -n;
            additional_code(n1); // в случае если число отрицательное нужен еще перевод в доп код (47-96)
        }
        else 
        { 
            string binar = ""; 
            for (int i = 0; i < 32; i++)
            {
                if (n % 2 == 0)
                {
                    binar += 0 ; // если последний число делится на два - последний бит - 0 => приписываем 0
                }
                else
                {
                    binar += 1 ; // ну а если 1 - значит приписываем 1
                }
                n >>= 1; // убираем последний бит
            }
            Console.WriteLine(binar);
        }


    }
    static void additional_code(int c)
    {
        string res ="";
        bool nxt_num = false;
        for (int i = 0; i< 16; i++)
        {
            if (nxt_num ) // это для одновременного перевода из обычного сразу в дополнительный, то есть с прибавление единички
            {
                if ((c & 1) == 0) // если у числа на конце несколько единичек то мы должны перебрасывать прибавленную в следующий разряд несколько раз
                {
                    res += 0;
                    

                }
                else // когда находим первый нолик приписываем в последний раз
                {
                    res += 1;
                    nxt_num = false;

                }
            }
            else
            {
                if (i == 0) // проверка младшего разряда, чтобы сразу перевести все в дополнительный код
                {
                    if ((c & 1) == 0) // если в прямом коде в начале стоит 0 => в обратно стоит единичка => нужно переносить прибавленную единичку в следующий разряд (обрабатывается на строке 56)
                    {
                        res += 1;
                        nxt_num = true;

                    }
                    else // ну а тут если стоит нолик в начале (младший разряд), значит просто добавляем один и получаем доп код.
                    {
                        res += 1;
                    }
                }
                else
                {
                    if ((c & 1) == 0) // если в прямом коде в начале стоит 0 => в обратном единичка 
                    {
                        res += 1;
                    }
                    else
                    {
                        res += 0; // и наоборот 
                    }
                }
            }
            c >>= 1;
        } 
        Console.WriteLine($"{res}");
        
    }
    public static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(i_byte(n,x));
        int o = int.Parse(Console.ReadLine());
        binary_n1(o);
        
    }
}

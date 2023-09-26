using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Qaysi fandan test o'tkazmoqchisiz (geografiya, matematika, sport)?");
        string fanNom = Console.ReadLine().ToLower();

        string testFayliNom = $"C:\\Users\\farho\\source\\repos\\files\\files\\testlar\\{fanNom}.txt";

        try
        {
            string[] testlar = File.ReadAllLines(testFayliNom);

            if (testlar.Length % 2 != 0)
            {
                Console.WriteLine("Noto'g'ri formatda test fayli.");
                return;
            }

            for (int i = 0; i < testlar.Length; i += 2)
            {
                string savol = testlar[i];
                string[] variantlar = testlar[i + 1].Split(';');

                Console.WriteLine(savol);

                for (int j = 0; j < variantlar.Length; j++)
                {
                    Console.WriteLine($"{(char)('a' + j)}) {variantlar[j]}");
                }

                Console.Write("Javobingizni kiriting (a, b, c, d): ");
                string foydalanuvchiJavobi = Console.ReadLine().ToLower();

                if (foydalanuvchiJavobi.Length == 1 && foydalanuvchiJavobi[0] >= 'a' && foydalanuvchiJavobi[0] < 'a' + variantlar.Length)
                {
                    if (variantlar[foydalanuvchiJavobi[0] - 'a'].StartsWith('*'))
                    {
                        Console.WriteLine("To'g'ri javob! E'tiboringiz uchun rahmat.");
                    }
                    else
                    {
                        Console.WriteLine("Noto'g'ri javob. To'g'ri javob: ");
                        for (int k = 0; k < variantlar.Length; k++)
                        {
                            if (variantlar[k].StartsWith('*'))
                            {
                                Console.WriteLine($"{(char)('a' + k)}) {variantlar[k].Substring(1)}");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Noto'g'ri javob formati.");
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Kechirasiz, '{fanNom}' faniga oid test topilmadi.");
        }
    }
}

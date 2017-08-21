using System.Collections;
using UnityEngine;

public class CodeGenerator
{

    public static string CodeGenerate(int len)
    {
        string[] characters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string code = "";

        for (int i = 0; i < len; i++)
        {
            code += characters[Random.Range(0, characters.Length)];
        }
        return code;
    }


}


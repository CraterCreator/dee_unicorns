using UnityEngine;
using System.Collections;

public class CodeGen 
{
	public static string GenerateCode(int len)
	{
		string [] consonants = {"b","bb", "c", "d","f","g","a","e","i","o","u","y","h","j","k","l","ll","m","n", "p","r","rr","s","sh","zh","t","tt","w","ie","ee","ae","i","o","y", "io"};
		string [] consonantsUpper = {"B", "C", "D","F","G","H","J","K","L","X","M","N", "P","R","S","T", "V","W","Z"};
		string [] nums = {"0","1","2","3","4","5","6","7","8","9"};
		string code = "";
		int random = 0;
		int c = 0;
		for(int i = 0; i < len; i++)
		{
			random = Random.Range(0,3);
			if(random == 0)
			{
				c = Random.Range(0,consonants.Length-1);
				code += consonants[c];
			}
			else if (random == 1)
			{
				c = Random.Range(0,consonantsUpper.Length-1);
				code += consonantsUpper[c];
			}
			else
			{
				c = Random.Range(0,nums.Length-1);
				code += nums[c];
			}
		}
		return code;
	}
}

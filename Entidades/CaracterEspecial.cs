using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CaracterEspecial
    {
        public string SacarTilde(string word)
        {
            if (word != "" && word != null)
            {
                word = word.Replace("á", "a");
                word = word.Replace("é", "e");
                word = word.Replace("í", "i");
                word = word.Replace("ó", "o");
                word = word.Replace("ú", "u");
                word = word.Replace("ü", "u");
                //word = word.Replace("ñ", "n");

                word = word.Replace("Á", "A");
                word = word.Replace("É", "E");
                word = word.Replace("Í", "I");
                word = word.Replace("Ó", "O");
                word = word.Replace("Ú", "U");
                word = word.Replace("Ü", "U");
                //word = word.Replace("Ñ", "n");
            }

            return word;
        }

        public string ConvertUNICODEtoChar(string word)
        {
            if (word != "" && word != null)
            {
                word = word.Replace("&#225;", "á");
                word = word.Replace("&#233;", "é");
                word = word.Replace("&#237;", "í");
                word = word.Replace("&#243;", "ó");
                word = word.Replace("&#250;", "ú");
                word = word.Replace("&#252;", "ü");
                word = word.Replace("&#241;", "ñ");

                word = word.Replace("&#193;", "Á");
                word = word.Replace("&#201;", "É");
                word = word.Replace("&#205;", "Í");
                word = word.Replace("&#211;", "Ó");
                word = word.Replace("&#218;", "Ú");
                word = word.Replace("&#220;", "Ü");
                word = word.Replace("&#209;", "Ñ");
            }

            return word;
        }
    }
}

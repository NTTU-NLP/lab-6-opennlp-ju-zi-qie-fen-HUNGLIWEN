using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using java.io;
using opennlp.tools.tokenize;
using System.Text.RegularExpressions;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] file = Directory.GetFiles(@"C:\10311171\lab-6-opennlp-ju-zi-qie-fen-HUNGLIWEN\lab6\Dataset", "*.html");
            StreamWriter sw = new StreamWriter(@"ReadByTokens.txt");
            foreach (string filename in file)
                using (StreamReader sr = new StreamReader(filename))
                {

                    while (sr.Peek() != -1)
                    {
                        string line = sr.ReadLine();
                        string[] tokens;
                        InputStream modelIn = new FileInputStream(@"C:\10311171\lab-6-opennlp-ju-zi-qie-fen-HUNGLIWEN\en-token.bin");
                        TokenizerModel model = new TokenizerModel(modelIn);
                        TokenizerME enTokenizer = new TokenizerME(model);
                        tokens = enTokenizer.tokenize(line);
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            sw.Write(tokens[i] + " ");

                            if (tokens[i].Equals("."))
                            {
                                sw.Write("\n");
                            }
                        }
                    }
                }
            sw.Close();
        }
    }
}

using System;
using System.IO;

namespace RayTracinginOneWeekendExamples
{
    public class Display
    {

        public string GetColor(int r, int g, int b)
        {
            return r + " " + g + " " + b;
        }


        public void DrawPPM(string[][] colors)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "image.ppm";
                if (!System.IO.File.Exists(path))
                {
                    FileStream stream = System.IO.File.Create(path);
                    stream.Close();
                    stream.Dispose();
                }

                File.Delete(path);

                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("P3");   
                    writer.WriteLine(colors[0].Length + " " + colors.Length);   
                    writer.WriteLine(255);  

                    for (int i = colors.Length - 1; i >= 0; i--)
                    {
                        string context = "";
                        for (int n = 0; n < colors[i].Length; n++)
                        {
                            context += colors[i][n] + " ";
                        }

                        writer.WriteLine(context);
                    }                        
                }

                Console.WriteLine("Finish!");
                long size = 0;

                using (FileStream file = System.IO.File.OpenRead(path))
                {
                     size = file.Length;
                }

               
            }
            catch
            {

            }

            
        }
    }
}
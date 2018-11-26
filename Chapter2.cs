namespace RayTracinginOneWeekendExamples
{

    //The vec3 class
    public class Chapter2
    {
        Display display = new Display();

        public void Run()
        {
            display.DrawPPM( CreateImageContent() );
        }

        private string[][] CreateImageContent()
        {
            int width = 500;
            int heigh = 600;

            string[][] colors = new string[heigh][];

            for (int i = heigh - 1; i >= 0; i--)
            {
                colors[i] = new string[width];
                for (int j = 0; j < colors[i].Length; j++)
                {
                    Vector3 vec = new Vector3( 0, 100, 100 );
                    colors[i][j] = display.GetColor( (int)vec.x, (int)vec.y, (int)vec.z );
                }
            }
            return colors;
        }
    }

}
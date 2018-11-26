namespace RayTracinginOneWeekendExamples
{
    public class Chapter1
    {
        Display display;

        public void Run()
        {
            if( display == null ){
                display = new Display();
            }

            display.DrawPPM( CreateImageContent() );
        }

        private string[][] CreateImageContent()
        {
            int width = 200;
            int heigh = 300;

            string[][] colors = new string[heigh][];

            for (int i = 0; i < heigh; i++)
            {
                colors[i] = new string[width];
                for (int j = 0; j < colors[i].Length; j++)
                {
                    colors[i][j] = GetColor( 0, 100, 100 );
                }
            }
            return colors;
        }

        private string GetColor(int r, int g, int b)
        {
            return r + " " + g + " " + b;
        }


    }
}
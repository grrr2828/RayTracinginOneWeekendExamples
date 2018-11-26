namespace RayTracinginOneWeekendExamples
{

    //Output an image
    public class Chapter1
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

            for (int i = 0; i < heigh; i++)
            {
                colors[i] = new string[width];
                for (int j = 0; j < colors[i].Length; j++)
                {
                    colors[i][j] = display.GetColor( 0, 100, 100 );
                }
            }
            return colors;
        }

    }
}
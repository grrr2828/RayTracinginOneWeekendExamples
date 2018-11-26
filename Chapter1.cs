namespace RayTracinginOneWeekendExamples
{

    //Output an image
    public class Chapter1
    {
        protected Display display = new Display();

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
                    colors[i][j] = display.GetColor( 0, 100, 100 );
                }
            }
            return colors;
        }

    }
}
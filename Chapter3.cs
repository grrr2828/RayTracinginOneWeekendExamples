namespace RayTracinginOneWeekendExamples
{

    //Rays, a simple camera, and background
    public class Chapter3
    {
        Display display = new Display();

        public void Run()
        {
            display.DrawPPM( CreateImageContent() );
        }

        private string[][] CreateImageContent()
        {
            int width = 600;
            int heigh = 300;

            string[][] colors = new string[heigh][];

            Vector3 lower_left_corner = new Vector3(-2f, -1f, -1f);
            Vector3 horizontal = new Vector3(4f, 0, 0);
            Vector3 vertical = new Vector3(0,2f,0);
            Vector3 origin = new Vector3(0,0,0);

            for (int i = heigh - 1; i >= 0; i--)
            {
                colors[i] = new string[width];
                for (int j = 0; j < colors[i].Length; j++)
                {
                    float u = (float)j / (float)width;
                    float v = (float)i / (float)heigh;

                    Ray r = new Ray( origin, lower_left_corner +  horizontal * u + vertical * v );
                    
                    var vec = GetColor(r);
                    colors[i][j] = display.GetColor( (int)(vec.x * 255), (int)(vec.y * 255), (int)(vec.z * 255) );
                }
            }
            return colors;
        }

        private Vector3 GetColor(Ray r)
        {
            Vector3 normalize = Vector3.Normalize( r.Direction() );
            float t = 0.5f * ( normalize.y + 1.0f );
            return ( 1f - t ) * new Vector3(1,1,1) + t * new Vector3( 0.5f, 0.7f, 1 );
        }
    }

}
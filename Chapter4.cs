namespace RayTracinginOneWeekendExamples
{

    //Adding a sphere
    public class Chapter4 : Chapter3
    {
        protected override string[][] CreateImageContent()
        {
            int width = 600;
            int heigh = 300;

            string[][] colors = new string[heigh][];

            Vector3 lower_left_corner = new Vector3(-2f, -1f, -1f);
            Vector3 horizontal = new Vector3(4f, 0, 0);
            Vector3 vertical = new Vector3(0,2f,0);
            Vector3 origin = new Vector3(0,0,0);

            Vector3 sphereCenter = new Vector3( 0, 0, -1 );
            float radius = 0.5f;

            for (int i = heigh - 1; i >= 0; i--)
            {
                colors[i] = new string[width];
                for (int j = 0; j < colors[i].Length; j++)
                {
                    float u = (float)j / (float)width;
                    float v = (float)i / (float)heigh;

                    Ray r = new Ray( origin, lower_left_corner +  horizontal * u + vertical * v );

                    Vector3 vec = Vector3.zero;
                    if( HitSphere( sphereCenter, radius, r ) ){
                        vec = new Vector3( 0.5f, 0.5f, 0.5f );
                    }else{
                        vec = GetColor( r );
                    }
                    
                    colors[i][j] = display.GetColor( (int)(vec.x * 255), (int)(vec.y * 255), (int)(vec.z * 255) );
                }
            }
            return colors;
        }

        private bool HitSphere(Vector3 center, float radius, Ray r)
        {
            Vector3 oc = r.Origin() - center;
            float a = Vector3.Dot( r.Direction(), r.Direction() );
            float b = 2.0f * Vector3.Dot( r.Direction(), oc  );
            float c = Vector3.Dot( oc, oc ) - radius * radius;

            float discriminant = b*b - 4*a*c;
            if (discriminant < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
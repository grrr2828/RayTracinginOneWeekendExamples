using System;
using System.Collections.Generic;

namespace RayTracinginOneWeekendExamples
{

    //Antialiasing
    public class Chapter6 : Chapter5_2
    {
        Camera camera  = new Camera();

        protected override string[][] CreateImageContent()
        {
            int width = 400;
            int heigh = 200;

            string[][] colors = new string[heigh][];

            int ns = 100;

            for (int i = heigh - 1; i >= 0; i--)
            {
                colors[i] = new string[width];
                for (int j = 0; j < colors[i].Length; j++)
                {
                    

                    Vector3 col = new Vector3(0,0,0);
                    for (int n = 0; n < ns; n++)
                    {
                        float u = (float)(j + Mathf.Random()) / (float)width;
                        float v = (float)(i +  Mathf.Random()) / (float)heigh;
                        Ray r = camera.GetRay( u, v );
                        Vector3 vec = GetColor( r, world );
                        col += vec;
                    }

                    col /= ns;

                    col = new Vector3((float)Mathf.Sqrt(col.x), (float)Mathf.Sqrt(col.y), (float)Mathf.Sqrt(col.z)); 

                    colors[i][j] = display.GetColor( (int)(col.x * 255), (int)(col.y * 255), (int)(col.z * 255) );
                }
            }
            return colors;
        }

        public Vector3 randomInUnitSphere(){
            Vector3 p;
            do{
                p =new Vector3((float)(Mathf.Random()), (float)(Mathf.Random()), (float)(Mathf.Random())) * 2 - (new Vector3(1.0f, 1.0f, 1.0f));
            }while (Vector3.Dot(p, p) >= 1.0f);
            return p;
        }


        protected Vector3 GetColor( Ray r, Hitable world)
        {
            Vector3 vec = Vector3.zero;
            HitRecord rec = new HitRecord();
            if( world.Hit(r, 0f, float.MaxValue, rec) ){
                var target = rec.p + rec.normal + randomInUnitSphere();
                return GetColor( new Ray( rec.p, target - rec.p ), world ) * 0.5f;
            }else{
                vec = GetColor( r );
            }

            return vec;
        }
    }

}
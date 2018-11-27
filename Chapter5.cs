using System;

namespace RayTracinginOneWeekendExamples
{

    //Surface normals and multiple objects.
    public class Chapter5 : Chapter4
    {

        protected override Vector3 GetColor( Vector3 center, float radius, Ray r)
        {
            Vector3 vec = Vector3.zero;

            float t = HitSphere( center, radius, r );

            if( t > 0 ){
                
                Vector3 p = r.PointAt(t);
                Vector3 N = (p - center).normalized;

                vec = new Vector3( N.x + 1, N.y + 1, N.z + 1 ) * 0.5f;

            }else{
                vec = GetColor( r );
            }

            return vec;
        }

        private float HitSphere(Vector3 center, float radius, Ray r)
        {
            Vector3 oc = r.Origin() - center;
            float a = Vector3.Dot( r.Direction(), r.Direction() );
            float b = 2.0f * Vector3.Dot( r.Direction(), oc  );
            float c = Vector3.Dot( oc, oc ) - radius * radius;

            float discriminant = b*b - 4*a*c;
            if (discriminant < 0)
            {
                return -1;
            }
            else
            {
                return (-b - (float)Mathf.Sqrt(discriminant)) / (2.0f * a);
            }
        }
    }


    public class Chapter5_2 : Chapter5
    {   
        
    } 

}
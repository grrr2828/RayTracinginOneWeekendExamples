using System;
using System.Collections.Generic;

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
        protected HitableList world;

        public Chapter5_2()
        {
            List<Hitable> objList = new List<Hitable>();
            objList.Add(new Sphere(new Vector3(0.0f,0.0f,-1.0f), 0.5f));
            objList.Add(new Sphere(new Vector3(0.3f,0.0f,-1.0f), 0.3f));
            objList.Add(new Sphere(new Vector3(0.0f,-100.5f,-1.0f), 100f));

            world = new HitableList( objList );
        
        }

        protected override Vector3 GetColor( Vector3 center, float radius, Ray r)
        {
            Vector3 vec = Vector3.zero;
            HitRecord rec = new HitRecord();
            if( world.Hit(r, 0f, float.MaxValue, rec) ){
                
                var N = rec.normal;
                vec = new Vector3( N.x + 1, N.y + 1, N.z + 1 ) * 0.5f;

            }else{
                vec = GetColor( r );
            }

            return vec;
        }

    } 

}
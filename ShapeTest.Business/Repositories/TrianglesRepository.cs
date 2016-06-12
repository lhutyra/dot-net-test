using System.Collections.Generic;
using ShapeTest.Business.Entities;

namespace ShapeTest.Business.Repositories
{
    public class TrianglesRepository : ITrianglesRepository
    {
        private readonly List<Triangle> _Triangles; 

        public TrianglesRepository()
        {
            _Triangles = new List<Triangle>
            {
                new Triangle
                (
                     "Triangle 1",
                     12.5,
                     13 
                ),
                new Triangle("Triangle 2",23.4,14),
               
                new Triangle("Triangle 3",42,22)              
            };
        }

        public event TriangleAddedEventHandler TriangleAdded;

        public List<Triangle> GetTriangles()
        {
            return _Triangles;
        }

        public void AddTriangle(Triangle triangle)
        {
            _Triangles.Add(triangle);
            OnTriangleAdded(triangle);
        }

        public bool RemoveTriangle(Triangle triangle)
        {
            return _Triangles.Remove(triangle);
        }

        protected void OnTriangleAdded(Triangle triangle)
        {
            TriangleAddedEventHandler handler = TriangleAdded;
            handler?.Invoke(this, new TriangleEventArgs(triangle));
        }
    }
}

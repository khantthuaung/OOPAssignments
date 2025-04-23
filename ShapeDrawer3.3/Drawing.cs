using System.ComponentModel.Design;
using System.IO.Pipelines;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing() :this(Color.White)
        {
            
        }
        public Color Background
        {
            get {return this._background;}
            set {this._background = value;}
        }
        public int ShapeCount
        {
            get{return this._shapes.Count;}
        }
        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }
        public void RemoveShape(Shape s)
        {
            _ = _shapes.Remove(s);
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }

        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.isAt(pt))
                {
                    s.Selected = s.isAt(pt);
                }
            }
        } 
        public List<Shape> SelectedShapes
        {
            //read-only
            get
            {  
                List<Shape> selectedShapes = new List<Shape>();
                foreach(Shape s in _shapes)
                {
                    if(s.Selected) 
                    selectedShapes.Add(s);
                }
                return SelectedShapes;
            }
        }   
    }
}
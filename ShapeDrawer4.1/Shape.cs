using System.Runtime.InteropServices;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private bool _selected = false;

        public Shape(Color color)
        {
            _color = color;
            _x = 0.0f;
            _y = 0.0f;
        }

        protected Shape() : this(Color.Yellow)
        {
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public bool Selected
        {
            get {return _selected;}
            set {_selected = value;}
        }
        
        //abstract methods
        public abstract void Draw();
        public virtual bool isAt(Point2D pt)
        {
            return false;
        }
        public abstract void DrawOutline();
    }
}
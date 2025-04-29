using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;

        private bool _selected = false;

        public Shape(int param)
        {
            _color = Color.LightGreen;
            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
        }
        public Color color
        {
            get { return _color; }
            set { _color = value; }
        }
        public float x
        {
            get { return _x; }
            set { _x = value; }
        }

        public float X { get; internal set; }

        public float y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int height
        {
            get { return _height; }
            set { _height = value; }
        }
        public bool Selected
        {
            get {return _selected;}
            set {_selected = value;}
        }
        public void Draw()
        {
            
            if (this._selected)
            {
                this.DrawOutline();
            }
            SplashKit.FillRectangle(_color, _x,_y, _width, _height);
        }
        public bool isAt(Point2D pt)
        {
            return (pt.X >= _x && pt.X <= _x + _width && pt.Y >= _y && pt.Y <= _y + _height);
        }
        public void DrawOutline()
        {
            int outlineWidth = 7;
            SplashKit.FillRectangle(Color.Black, _x-outlineWidth, _y-outlineWidth, _width+outlineWidth*2, _height+outlineWidth*2);

        }
        

    }

}
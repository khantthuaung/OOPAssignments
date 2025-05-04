using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;
        /// Constructors
        public MyRectangle(Color color, int x, int y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public MyRectangle() : this(Color.Green, 0, 0, 112, 112) { }
        /// Properties
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }
        public override void DrawOutline()
        {
            int outlineWidth = 7;
            SplashKit.FillRectangle(Color.Black, _x - outlineWidth, _y - outlineWidth, _width + outlineWidth * 2, _height + outlineWidth * 2);
        }

        public override bool isAt(Point2D pt)
        {
            return (pt.X >= _x && pt.X <= _x + _width && pt.Y >= _y && pt.Y <= _y + _height);
        }
    }
}
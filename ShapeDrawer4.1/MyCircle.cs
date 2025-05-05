using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;
        public MyCircle() : this(Color.Blue, 62)
        {
        }
        public MyCircle(Color color, int radius) : base()
        {
            _radius = radius;
        }
        /// Properties
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        //overriddedn methods
        public override void Draw()
        {
            if (Selected)
            {
                this.DrawOutline();
            }
            SplashKit.FillCircle(Color, X, Y, _radius);
        }
        public override void DrawOutline()
        {
            int outlineWidth = 2;
            SplashKit.FillCircle(Color.Black, X, Y, Radius + outlineWidth);
        }
        public override bool isAt(Point2D pt)
        {
            // return (pt.X >= X - Radius && pt.X <= X + Radius && pt.Y >= Y - Radius && pt.Y <= Y + Radius);
            Circle c = SplashKit.CircleAt(X, Y, Radius);
            return SplashKit.PointInCircle(pt, c);
        }
    }
}
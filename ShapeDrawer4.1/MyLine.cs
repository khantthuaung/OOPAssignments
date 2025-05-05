using System.Runtime.Intrinsics.X86;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;
        public MyLine() : this(Color.Red)
        {
        }
        public MyLine(Color color)
        {
            X = SplashKit.MouseX();
            Y = SplashKit.MouseY();
            _endX = X + 200;
            _endY = Y;
        }
        //properties
        public float EndX
        {
            get {return _endX;}
            set {_endX = value;}
        }
        public float EndY
        {
            get {return _endY;}
            set {_endY = value;}
        }
        //overridden methods
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Color, X, Y, _endX, _endY);
        }
        public override void DrawOutline()
        {
            int radius = 3;
            SplashKit.DrawCircle(Color.Black, X, Y, radius); //start cirle
            SplashKit.DrawCircle(Color.Black, _endX, _endY, radius); //end circle
        }
        public override bool isAt(Point2D pt)
        {
            float minX = Math.Min(X, _endX) - 3;
            float maxX = Math.Max(X, _endX) + 3;
            float minY = Math.Min(Y, _endY) - 3;
            float maxY = Math.Max(Y, _endY) + 3;

            return (pt.X >= minX && pt.X <= maxX && pt.Y >= minY && pt.Y <= maxY);
        }
    }
}
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
        public MyLine(Color color):base(color)
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
            Line line = SplashKit.LineFrom(X, Y, _endX, _endY);
            return SplashKit.PointOnLine(pt, line, 5);
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();
        }
    }
}
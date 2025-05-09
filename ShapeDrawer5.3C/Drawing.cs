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
        public Drawing() : this(Color.White)
        {

        }
        public Color Background
        {
            get { return this._background; }
            set { this._background = value; }
        }
        public int ShapeCount
        {
            get { return this._shapes.Count; }
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
        public void Save(string filename)
        {
            StreamWriter writer;
            writer = new StreamWriter(filename);
            writer.WriteColor(Background);
            writer.WriteLine(_shapes.Count);
            foreach (Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
            writer.Close();
        }
        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                Background = reader.ReadColor();
                int count = reader.ReadInteger();
                Shape s;
                _shapes.Clear();
                for (int i = 0; i < count; i++)
                {
                    string kind = reader.ReadLine();
                    
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException("Unknown Shape kind: " + kind);

                    }
                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                s.Selected = s.isAt(pt);
            }
        }
        public List<Shape> SelectedShapes
        {
            //read-only
            get
            {
                List<Shape> selectedShapes = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected) selectedShapes.Add(s);
                }
                return selectedShapes;
            }
        }
    }
}
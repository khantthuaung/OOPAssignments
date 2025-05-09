using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
        }
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                
                if(SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if(SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            newShape = new MyCircle();
                            break;
                        default:
                            newShape = new MyRectangle();
                            break;
                    }
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    myDrawing.AddShape(newShape);
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    int count = 2; //studentID= 105292912

                    for (int i = 0; i < count; i++)
                    {
                        float startX = SplashKit.MouseX();
                        float startY = SplashKit.MouseY() + i * 40;

                        
                        MyLine newLine = new MyLine();
                        newLine.X = startX;
                        newLine.Y = startY;
                        newLine.EndX = startX + 200;
                        newLine.EndY = startY; // horizontal line

                        myDrawing.AddShape(newLine);
                    }

                }
                if(SplashKit.KeyTyped(KeyCode.SKey))
                {
                    //saving total 7 shapes
                    myDrawing.Save("TestDrawing.txt"); //id = 105292912 -> 5+X -> X = 5%2 = 2 -> 5+2 = 7
                    Console.WriteLine("Drawing savedd!!");
                }
               if(SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("TestDrawing.txt");
                       Console.WriteLine("Drawing loaded!!"); 
                    }catch(Exception e)
                    {
                        Console.Error.WriteLine("Error loading file:{0}",e.Message);
                    }
                    // myDrawing.Load("TestDrawings.txt");
                } 
                myDrawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);

        }

    }
}

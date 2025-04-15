using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Shape myShape = new Shape(100);

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.x = SplashKit.MouseX();
                    myShape.y = SplashKit.MouseY();
                }
                 if (SplashKit.KeyTyped(KeyCode.SpaceKey) && myShape.isAt(SplashKit.MousePosition()))
                {
                    myShape.color = SplashKit.RandomColor();
                }
                
                myShape.Draw(); 
                SplashKit.RefreshScreen();
            }while(!window.CloseRequested);

        }
        
    }
}

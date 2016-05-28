using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfTips
{
    /// <summary>
    /// Interaction logic for TranslateTransform.xaml
    /// </summary>
    public partial class TranslateTransformControl : UserControl
    {
        public TranslateTransformControl()
        {
            InitializeComponent();
        }

        // The sample application contains a window with a blue rectangle and five buttons that
        // can be used to move rectangle. By pressing the 'Hide Left' button the rectangel is moved
        // to the left beyond the left side of the window. Similarly by pressing the 'Hide Right' and
        // 'Hide Up" buttons the rectangle is moved beyond the right and top sides of the window respectively.
        // This is the first article about interesting, I hope so, tips about
        // WPF. In this first article I discuss the Translate trasformation.
        // When I was first looking into this type of transformation I was 
        // a little bit confused so I decided to present some examples that
        // hopefully make things more clear. The sample application contains 
        // a blue rectangle that will be moved to the left and four buttons.
        // Let's check first the implementation for Hide Left. We want to hide
        // the rectangle moving it to beyond the left edge of the window.
        // So first we are using the TranslatePoint function to retrieve the
        // position of the rectangle. We want to move the rectangle to the left
        // by <the current distance of the rectangle from the left size (which is
        // the value of property X in the returned point> + <rectangle's width>.
        // This is what the second line of code does. We do not need to move the
        // rectangle in Y axis so the point.Y = 0. The important thing is that
        // the Point represents the X and Y distance by which the rectange should
        // be moved in the X and Y axis relatively to its original position. The 
        // latter was something that really confused me so let's examine the code
        // for the Hide right functionality. The logic is the same but what's interesting
        // is that even if the rectangle is hidden to the left clicking the 'Hide Right' button
        // will move the rectange beyond the right side of the window. Also if you notice the 
        // code that moves the rectange to its original position no matter where it is the Point
        // instance being used has the X and Y equal to zero, which is logicall since as mentioned previously 
        // it represents the distance the rectancle is to be moved from its original position which.
        // Notice that if we want to move the rectangle each time the move button is clicked to the right
        // we have to take into account also the avigationTransform.X which represents the distance the 
        // rectangle has been moved from its original position. 
        private void HideLeftButtonClick(object sender, RoutedEventArgs e)
        {
            Point point = this.TranslatePoint(new Point(), Rect);
            point.X -= Rect.ActualWidth;
            point.Y = 0;
            navigationTransform.AnimateTo(point, TimeSpan.FromSeconds(1));
        }

        private void ResetButtonClick(object sender, RoutedEventArgs e)
        {
            Point original = new Point(0,0);
            navigationTransform.AnimateTo(original, TimeSpan.FromSeconds(1));
        }

        private void HideRightButtonClick(object sender, RoutedEventArgs e)
        {
            Point point = new Point(this.ActualWidth, 0);
            navigationTransform.AnimateTo(point, TimeSpan.FromSeconds(1));
        }

        private void MoveButtonClick(object sender, RoutedEventArgs e)
        {
            Point point = new Point();
            point.X = navigationTransform.X + 100;
            navigationTransform.AnimateTo(point, TimeSpan.FromSeconds(1));
        }

        private void HideUptButtonClick(object sender, RoutedEventArgs e)
        {
            Point point = this.TranslatePoint(new Point(), Rect);
            point.Y -= Rect.ActualHeight;
            point.X = navigationTransform.X;
            navigationTransform.AnimateTo(point, TimeSpan.FromSeconds(1));
        }

    }
}

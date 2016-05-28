using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfTips
{
    public static class TranslateTransformExtensions
    {
        public static void AnimateTo(this TranslateTransform translateTransform, Point point, TimeSpan duration)
        {
            StartAnimation(translateTransform, TranslateTransform.XProperty, point.X, duration);
            StartAnimation(translateTransform, TranslateTransform.YProperty, point.Y, duration);
        }

        private static void StartAnimation(TranslateTransform translateTransform, DependencyProperty dependencyProperty,
                                            double toValue, TimeSpan duration)
        {
            var animation = new DoubleAnimation
            {
                To = toValue,
                Duration = duration,
                EasingFunction = new QuadraticEase()
            };
            translateTransform.BeginAnimation(dependencyProperty, animation);
        }
    }
}

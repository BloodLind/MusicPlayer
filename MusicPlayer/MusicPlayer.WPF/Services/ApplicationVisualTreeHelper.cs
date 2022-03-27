using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicPlayer.WPF.Services
{
    public static class ApplicationVisualTreeHelper
    {
        private static void GetVisualChildren<T>(DependencyObject current, Collection<T> children) where T : DependencyObject
        {
            if (current != null)
            {
                if (current.GetType() == typeof(T))
                {
                    children.Add((T)current);
                }

                for (int i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(current); i++)
                {
                    GetVisualChildren<T>(System.Windows.Media.VisualTreeHelper.GetChild(current, i), children);
                }
            }
        }

        public static Collection<T> GetVisualChildren<T>(DependencyObject current) where T : DependencyObject
        {
            if (current == null)
            {
                return null;
            }

            Collection<T> children = new Collection<T>();

            GetVisualChildren<T>(current, children);

            return children;
        }

        public static Target GetVisualChild<Target, Parent>(Parent templatedParent)
            where Target : FrameworkElement
            where Parent : FrameworkElement
        {
            Collection<Target> children = ApplicationVisualTreeHelper.GetVisualChildren<Target>(templatedParent);

            foreach (Target child in children)
            {
                if (child.TemplatedParent == templatedParent)
                {
                    return child;
                }
            }

            return null;
        }

    }
}

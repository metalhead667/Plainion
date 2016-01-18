﻿using System.Windows;
using System.Windows.Controls;
using Plainion.Windows.Controls.Tree.Cmp;
using Plainion.Windows.Interactivity.DragDrop;

namespace Plainion.Windows.Controls.Tree.Forest
{
    public partial class TreeEditor : UserControl, IDropable
    {
        public TreeEditor( )
        {
            InitializeComponent();
        }

        public static DependencyProperty RootProperty = DependencyProperty.Register("Root", typeof(Node), typeof(TreeEditor),
            new FrameworkPropertyMetadata(null));

        public Node Root
        {
            get { return (Node)GetValue(RootProperty); }
            set { SetValue(RootProperty, value); }
        }

        public static DependencyProperty FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(TreeEditor),
            new FrameworkPropertyMetadata(OnFilterChanged));

        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == e.OldValue)
            {
                return;
            }

            ((TreeEditor)d).OnFilterChanged();
        }

        private void OnFilterChanged()
        {
            if (Root == null)
            {
                return;
            }

            Root.ApplyFilter(Filter);
        }

        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        void IDropable.Drop(object data, DropLocation location)
        {
            var droppedElement = data as Node;

            if (droppedElement == null)
            {
                return;
            }

            //ProjectService.Project.AddChildTo( droppedElement.Node, Node );
        }

        string IDropable.DataFormat
        {
            get
            {
                return typeof(Node).FullName;
            }
        }

        bool IDropable.IsDropAllowed(object data, DropLocation location)
        {
            return true;
        }
    }
}
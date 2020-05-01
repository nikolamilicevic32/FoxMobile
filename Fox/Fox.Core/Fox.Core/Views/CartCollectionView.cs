using System;
using MvvmCross.Commands;
using Xamarin.Forms;

namespace Fox.Core.Views
{
    public class ParrentCollectionView : CollectionView
    {
        public static BindableProperty ParentBindingContextProperty = BindableProperty.Create(nameof(ParentBindingContext), typeof(IMvxCommand), typeof(CollectionView),null, BindingMode.TwoWay);

        public IMvxCommand ParentBindingContext
        {
            get { return (IMvxCommand)GetValue(ParentBindingContextProperty); }
            set { SetValue(ParentBindingContextProperty, value); }
        }
    }

    public class StackScrollContent : StackLayout
    {
        public static BindableProperty ScrollViewProperty = BindableProperty.Create(nameof(ScrollView), typeof(ScrollView), typeof(ScrollView), new ScrollView(), BindingMode.TwoWay);

        public ScrollView ScrollView
        {
            get { return (ScrollView)GetValue(ScrollViewProperty); }
            set { SetValue(ScrollViewProperty, value); }
        }
    }
}


using Xamarin.Forms;

namespace Fox.Core
{
    public partial class CircleView : BoxView
    {
        public static readonly BindableProperty BadgeCornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(CircleView), 0.0);
        public double BadgeCornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
}

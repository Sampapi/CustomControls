using Contacts.Wrappers;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlsLibrary
{
    public class AddressCustomControl : Control
    {
        static AddressCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AddressCustomControl), new FrameworkPropertyMetadata(typeof(AddressCustomControl)));
      }

        public AddressWrapper Address
        {
            get => (AddressWrapper)GetValue(AddressProperty);
            set => SetValue(AddressProperty, value);
        }

        public static readonly DependencyProperty AddressProperty =
                      DependencyProperty.Register("Address", typeof(AddressWrapper), typeof(AddressCustomControl),
                          new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                          new PropertyChangedCallback(OnAddressPropertyChanged)));

        private static void OnAddressPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not AddressCustomControl) { return; }

        }

        public PhoneNumberWrapper HomePhoneNumber
        {
            get => (PhoneNumberWrapper)GetValue(HomePhoneNumberProperty);
            set => SetValue(HomePhoneNumberProperty, value);
        }

        public static readonly DependencyProperty HomePhoneNumberProperty =
                      DependencyProperty.Register("HomePhoneNumber", typeof(PhoneNumberWrapper), typeof(AddressCustomControl),
                          new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
                           //new PropertyChangedCallback(OnTextPropertyChanged)));

        //private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    AddressCustomControl control = d as AddressCustomControl;
        //    if (control is null) { return; }

        //    control.OnTextPropertyChanged(e.Property, (string)e.OldValue, (string)e.NewValue);
        //}

        //protected virtual void OnTextPropertyChanged(DependencyProperty property, string oldValue, string newValue)
        //{

        //}

    
        //private const string _streetNumberPart = "PART_Number";
        //private const string _streetNamePart = "PART_Street";
        //private const string _cityPart = "PART_City";
        private const string _provStatePart = "PART_ProvState";
        //private const string _countryPart = "PART_Country";
        //private const string _postalCodePart = "PART_PostalCode";
        //private const string _homePhoneNumberPart = "PART_HomePhoneNumber";
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //var streetNumber = GetTemplateChild(_streetNumberPart) as TextBox;
            //var streetName = GetTemplateChild(_streetNamePart) as TextBox;
            //var City = GetTemplateChild(_cityPart) as TextBox;
            var ProvState = GetTemplateChild(_provStatePart) as TextBox;
            //var Country = GetTemplateChild(_countryPart) as TextBox;
            //var PostalCode = GetTemplateChild(_postalCodePart) as TextBox;
            //var HomePhoneNumber = GetTemplateChild(_homePhoneNumberPart) as TextBox;

            if (string.IsNullOrWhiteSpace(ProvState.Text)) { ProvState.Text = "Quebec"; }
            //if (string.IsNullOrWhiteSpace(Country.Text)) { Country.Text = "Canada"; }

        }

       

    }


}

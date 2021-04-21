using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace WpfResourceLibrary.Behaviors
{
    public static class ChangeBehavior
    {
        public static readonly DependencyProperty IsActiveProperty;
        public static readonly DependencyProperty IsChangedProperty;
        public static readonly DependencyProperty OriginalValueProperty;
        public static readonly DependencyProperty OriginalValueConverterProperty;

        private static readonly Dictionary<Type, DependencyProperty> _defaultProperties;

        static ChangeBehavior()
        {
            IsActiveProperty = DependencyProperty.RegisterAttached("IsActive", typeof(bool), typeof(ChangeBehavior), new PropertyMetadata(false, OnIsActivePropertyChanged));
            IsChangedProperty = DependencyProperty.RegisterAttached("IsChanged", typeof(bool), typeof(ChangeBehavior), new PropertyMetadata(false));
            OriginalValueProperty = DependencyProperty.RegisterAttached("OriginalValue", typeof(object), typeof(ChangeBehavior), new PropertyMetadata(null));
            OriginalValueConverterProperty = DependencyProperty.RegisterAttached("OriginalValueConverter", typeof(IValueConverter), typeof(ChangeBehavior), new PropertyMetadata(null, OnOriginalValueConverterPropertyChanged));

            _defaultProperties = new Dictionary<Type, DependencyProperty>
            {
                [typeof(TextBox)] = TextBox.TextProperty,
                [typeof(CheckBox)] = ToggleButton.IsCheckedProperty,
                [typeof(DatePicker)] = DatePicker.SelectedDateProperty,
                [typeof(ComboBox)] = Selector.SelectedValueProperty
            };
        }

        public static bool GetIsActive(DependencyObject obj) => (bool)obj.GetValue(IsActiveProperty);
        public static void SetIsActive(DependencyObject obj, bool value) => obj.SetValue(IsActiveProperty, value);

        public static bool GetIsChanged(DependencyObject obj) => (bool)obj.GetValue(IsChangedProperty);
        public static void SetIsChanged(DependencyObject obj, bool value) => obj.SetValue(IsChangedProperty, value);

        public static object GetOriginalValue(DependencyObject obj) => (object)obj.GetValue(OriginalValueProperty);
        public static void SetOriginalValue(DependencyObject obj, object value) => obj.SetValue(OriginalValueProperty, value);

        public static IValueConverter GetOriginalValueConverter(DependencyObject obj) => (IValueConverter)obj.GetValue(OriginalValueConverterProperty);
        public static void SetOriginalValueConverter(DependencyObject obj, IValueConverter value) => obj.SetValue(OriginalValueConverterProperty, value);


        private static void OnIsActivePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (_defaultProperties.ContainsKey(dependencyObject.GetType()))
            {
                var defaultProperty = _defaultProperties[dependencyObject.GetType()];
                if ((bool)e.NewValue)
                {
                    var binding = BindingOperations.GetBinding(dependencyObject, defaultProperty);
                    if (binding is not null)
                    {
                        string bindingPath = binding.Path.Path;
                        var newBinding = new Binding(bindingPath + "IsChanged")
                        {
                            RelativeSource = binding.RelativeSource
                        };
                        BindingOperations.SetBinding(dependencyObject, IsChangedProperty, newBinding);
                        CreateOriginalValueBinding(dependencyObject, bindingPath + "OriginalValue", binding.RelativeSource);
                    }
                }
                else
                {
                    BindingOperations.ClearBinding(dependencyObject, IsChangedProperty);
                    BindingOperations.ClearBinding(dependencyObject, OriginalValueProperty);
                }
            }
        }

        private static void OnOriginalValueConverterPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var originalValueBinding = BindingOperations.GetBinding(dependencyObject, OriginalValueProperty) as Binding;
            if (originalValueBinding is not null)
            {
                CreateOriginalValueBinding(dependencyObject, originalValueBinding.Path.Path, originalValueBinding.RelativeSource);
            }
        }

        private static void CreateOriginalValueBinding(DependencyObject dependencyObject, string originalValueBindingPath, RelativeSource relativeSource)
        {
            var newBinding = new Binding(originalValueBindingPath)
                { Converter = GetOriginalValueConverter(dependencyObject), 
                  ConverterParameter = dependencyObject,
                  RelativeSource = relativeSource
            };

            BindingOperations.SetBinding(dependencyObject, OriginalValueProperty, newBinding);
        }
    }
}

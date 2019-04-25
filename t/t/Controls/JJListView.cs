using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace t.Controls
{
    public class JJListView : ListView, IDisposable
    {

        public JJListView(ListViewCachingStrategy strategy) : base(strategy)
        {

            ItemTapped += OnItemTapped;
        }

        public ICommand ItemSelectedCommand
        {
            get
            {
                return (ICommand)GetValue(ItemSelectedCommandProperty);
            }

            set
            {
                SetValue(ItemSelectedCommandProperty, (ICommand)value);
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            this.SelectedItem = null;

            if (e.Item != null && this.ItemSelectedCommand != null)
            {
                this.ItemSelectedCommand.Execute(e.Item);
            }
        }

        public static readonly BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(
                                        nameof(ItemSelectedCommand),
                                        typeof(ICommand),
            typeof(JJListView));



        public float DividerHeight
        {
            get;
            set;
        }

        public void Dispose()
        {

            ItemTapped -= OnItemTapped;
        }
    }
}

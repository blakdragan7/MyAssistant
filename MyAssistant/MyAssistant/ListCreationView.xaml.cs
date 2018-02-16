using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListCreationView : ContentView
    {
        public ListCreationView()
        {
            InitializeComponent();

            ListEntry.TextChanged += ListEntry_TextChanged;
            ListEntry.Completed += ListEntry_Completed;
        }

        private async void ListEntry_Completed(object sender, EventArgs e)
        {
            if (ListEntry.Text.Length > 0)
            {
                ListTable row = new ListTable
                {
                    ID = null,
                    UserID = @"Some User ID",
                    EntryText = ListEntry.Text,
                    EventType = @"Unkown"
                };
                await ListTableManager.DefaultManager.SaveTaskAsync(row);
            }
        }

        private void ListEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ListEntry.Text.Length > 0)
            {
                 // Example of find @ sign
                char lc = ListEntry.Text[ListEntry.Text.Length - 1];
                if (lc == '@')
                {
                    ListEntry.Text = "At Sign !";
                }
            }
        }
    }
}
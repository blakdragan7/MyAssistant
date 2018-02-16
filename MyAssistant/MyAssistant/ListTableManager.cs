using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyAssistant
{
    class ListTableManager
    {
        static ListTableManager instance = new ListTableManager();
        MobileServiceClient client;

        IMobileServiceTable<ListTable> listTable;

        const string offlineDbPath = @"localstore.db";

        private ListTableManager()
        {
            this.client = new MobileServiceClient(@"https://mymobileassistant.azurewebsites.net");
            listTable = client.GetTable<ListTable>();
            DefaultManager = this;
        }

        public static ListTableManager DefaultManager
        {
            get;
            private set;
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public bool IsOfflineEnabled
        {
            get { return listTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<ListTable>; }
        }

        public async Task<ObservableCollection<ListTable>> GetListsAsync(bool syncItems = false)
        {
            try
            {
                IEnumerable<ListTable> items = await listTable
                    .Where(listRow => listRow.UserID != null)
                    .ToEnumerableAsync();

                return new ObservableCollection<ListTable>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task SaveTaskAsync(ListTable item)
        {
            if (item.ID == null)
            {
                await listTable.InsertAsync(item);
            }
            else
            {
                await listTable.UpdateAsync(item);
            }
        }

    }
}

using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Fox.CheckSystem
{
    public class CheckSystem
    {
        private TaskCompletionSource<bool> InternetAvailability = new TaskCompletionSource<bool>();

        public async Task<bool> CheckInternetConnection()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            Task<bool> _internetTask = InternetAvailability.Task;

            return await _internetTask;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var access = e.NetworkAccess;
            var profiles = e.ConnectionProfiles;

            if(access == NetworkAccess.Internet)
            {
                InternetAvailability.SetResult(true);
            }

            InternetAvailability.SetResult(false);
        }
    }
}

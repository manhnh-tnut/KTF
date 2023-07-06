using System.Net.NetworkInformation;

namespace KTF.WebApp.Helpers
{
    public class NetworkHepler
    {
        public static string GetPhysicalAddress()
        {
            var ethernet = NetworkInterface.GetAllNetworkInterfaces().Where(i => i.NetworkInterfaceType != NetworkInterfaceType.Loopback).FirstOrDefault();
            if (ethernet == null)
            {
                return null;
            }
            PhysicalAddress address = ethernet.GetPhysicalAddress();
            return BitConverter.ToString(address.GetAddressBytes());
        }
    }
}

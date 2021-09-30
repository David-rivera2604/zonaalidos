using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web;

namespace Architect.Utilities.Helpers
{
    internal static partial class Connection
    {
        /// <summary>
        /// Determina si la ip es local o no
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsLocalIpAddress()
        {

            if ((HttpContext.Current != null))
            {
                if ((HttpContext.Current.Request != null))
                {
                    if ((HttpContext.Current.Request.Url != null))
                    {
                        if (!string.IsNullOrEmpty(HttpContext.Current.Request.Url.Host))
                        {
                            return IsLocalIpAddress(HttpContext.Current.Request.Url.Host);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Determina si la ip es local o no
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsLocalIpAddress(string host)
        {
            try
            {
                IPAddress[] hostIPs = Dns.GetHostAddresses(host);
                // get local IP addresses
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                if (!HttpContext.Current.Request.IsLocal)
                {
                    return false;
                }

                foreach (IPAddress hostIP in hostIPs)
                {
                    // is localhost
                    if (IPAddress.IsLoopback(hostIP))
                    {
                        return true;
                    }

                    // is local address
                    foreach (IPAddress localIP in localIPs)
                    {
                        if (hostIP.Equals(localIP))
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        /// Methodo que estrae el nombre de la maquina que hace el requeste
        /// </summary>
        /// <param name="ipSource">Ip de origen</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string NameHostFromIp(string ipSource)
        {
            try
            {
                string hostName = Dns.GetHostEntry(ipSource).HostName;
                if (!string.IsNullOrEmpty(hostName))
                {
                    return hostName.ToUpper();
                }
                else
                {
                    return ipSource;
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return ipSource;
            }
        }

        /// <summary>
        /// Trying to get the public IP
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetIPPublic()
        {
            //try
            //{
            //    string ExternalIP =  GeoLocation.Located().Ip;
            //    return ExternalIP;
            //}
            //catch
            //{
                return GetIPRequest();
            //}
        }



        /// <summary>
        /// Trying to get the public IP
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetIPEnviroment()
        {
            try
            {
                if (IsLocalIpAddress())
                {
                    return NameHostFromIp(GetIPOnlyRequest());
                }
                else
                {
                    return GetIPOnlyRequest();
                }
            }
            catch
            {
                return GetIPRequest();
            }
        }


        /// <summary>
        /// Get ip request.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetIPRequest()
        {
            return NameHostFromIp(GetIPOnlyRequest());
        }

        public static string GetIPOnlyRequest()
        {
            string Result = string.Empty;
            if (System.Web.Hosting.HostingEnvironment.IsHosted)
            {

                try
                {
                    if (HttpContext.Current != null)
                    {
                        if (HttpContext.Current.Request != null)
                        {
                            if (HttpContext.Current.Request.ServerVariables != null)
                            {
                                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                                {
                                    Result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                                }
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(Result))
                    {
                        if (HttpContext.Current != null)
                        {
                            if (HttpContext.Current.Request != null)
                            {
                                if (HttpContext.Current.Request.ServerVariables != null)
                                {
                                    if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
                                    {
                                        Result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                                    }
                                }
                            }
                        }
                    }

                    //if (string.IsNullOrEmpty(Result) && (OperationContext.Current != null))
                    //{
                    //    RemoteEndpointMessageProperty clientEndpoint = OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                    //    Result = clientEndpoint.Address;
                    //}

                    if (string.Equals(Result, "::1", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Result = "127.0.0.1";
                    }

                    if (string.IsNullOrEmpty(Result))
                    {
                        Result = "127.0.0.1";
                    }

                    return Result;
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    return NameHostFromIp("127.0.0.1");
                }
            }
            else
            {
                try
                {
                    IPHostEntry SystemAC = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (var item in SystemAC.AddressList)
                    {
                        if (item.AddressFamily == AddressFamily.InterNetwork)
                        {
                            Result = item.ToString();
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    return Result;
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    return NameHostFromIp("127.0.0.1");
                }
            }
        }

        public static IPAddress GetBroadcastAddress(IPAddress address, IPAddress subnetMask)
        {
            byte[] ipAdressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
            {
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");
            }

            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i <= broadcastAddress.Length - 1; i++)
            {
                broadcastAddress[i] = Convert.ToByte(ipAdressBytes[i] | (subnetMaskBytes[i] ^ 255));
            }
            return new IPAddress(broadcastAddress);
        }

        public static IPAddress GetNetworkAddress(IPAddress address, IPAddress subnetMask)
        {
            byte[] ipAdressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
            {
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");
            }

            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i <= broadcastAddress.Length - 1; i++)
            {
                broadcastAddress[i] = Convert.ToByte(ipAdressBytes[i] & (subnetMaskBytes[i]));
            }
            return new IPAddress(broadcastAddress);
        }

        public static bool IsInSameSubnet(string ipServer, string ipHost, string subnetMask)
        {
            return IsInSameSubnet(IPAddress.Parse(ipServer), IPAddress.Parse(ipHost), IPAddress.Parse(subnetMask));
        }

        public static bool IsInSameSubnet(IPAddress ipServer, IPAddress ipHost, IPAddress subnetMask)
        {
            IPAddress network1 = GetNetworkAddress(ipHost, subnetMask);
            IPAddress network2 = GetNetworkAddress(ipServer, subnetMask);

            return network1.Equals(network2);
        }

        public static IPAddress GetSubnetMask()
        {
            return GetSubnetMask(IPAddress.Parse(GetIPOnlyRequest()));
        }

        public static IPAddress GetSubnetMask(IPAddress address)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (address.Equals(unicastIPAddressInformation.Address))
                        {
                            return unicastIPAddressInformation.IPv4Mask;
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Can't find subnet-mask for IP address '{0}'", address));
        }

    }
}

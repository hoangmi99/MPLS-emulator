using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Tools;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace Router
{
    public class RouterConfigReader
    {
        public RouterConfigReader()
        {
        }

        /*public class NHLFERow
        {
            public int id { get; set; } 
            public int port_in { get; set; }
            public int label_in { get; set; }
            public int port_out { get; set; }
            public int label_out { get; set; }
            public int StackPtr { get; set; }
            public String method { get; set; }
            public String next_method { get; set; }
        }*/

        private class RouterModel
        {
            
            public String IpAddress { get; set; }
            public int Port { get; set; }
            public String Name { get; set; }
            public int CloudPort { get; set; }
            public String CloudIP { get; set; }
            public String ManagementIP { get; set; }
            public int ManagementPort { get; set; }
            
            
        }

        public static void LoadRouterConfig(Router router, String filename)
        {
            var jsonFile = File.ReadAllText(filename);
            RouterModel routerModel  = JsonSerializer.Deserialize<RouterModel>(jsonFile);

            //router.CloudIP = IPAddress.Parse(routerModel.CloudIP);
            //router.CloudPort = routerModel.CloudPort;
            //router.IpAddress = IPAddress.Parse(routerModel.IpAddress);
            //router.Port = routerModel.Port;
            router.EndPoint = new IPEndPoint(IPAddress.Parse(routerModel.IpAddress), routerModel.Port);
            router.CableCloudEndPoint = new IPEndPoint(IPAddress.Parse(routerModel.CloudIP), routerModel.CloudPort);
            router.ManagementEndPoint = new IPEndPoint(IPAddress.Parse(routerModel.ManagementIP), routerModel.ManagementPort);
            router.Name = routerModel.Name;
            //router.ComutationList = new Dictionary<int, NHFLEEntry>();

            /*foreach(NHLFERow element in routerModel.NHLFEEntries)
            {
                Console.WriteLine($"{element.id}, {element.port_in}, {element.label_in}, {element.port_out}, {element.label_out}, {element.method}, {element.next_method}, ");
                router.ComutationList.Add(element.id, new NHFLEEntry(element.port_in, element.label_in, element.port_out, element.label_out, element.StackPtr, element.method, element.next_method));
            }*/

        }
    }
}

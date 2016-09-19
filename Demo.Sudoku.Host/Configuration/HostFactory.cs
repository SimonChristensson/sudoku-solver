using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Threading;
using Autofac.Integration.Wcf;
using Demo.Sudoku.Services;


namespace Demo.Sudoku.Host.Configuration  
{
    public static class HostFactory
    {
        public static WebServiceHost CreateHost(string address)
        {
            WebServiceHost host = new WebServiceHost(typeof(WebServices), new Uri(address));
            host.AddDependencyInjectionBehavior<IWebServices>(ContainerFactory.Builder);
            return host;
        }
    }
}

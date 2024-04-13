// See https://aka.ms/new-console-template for more information
using gRPC;
using Grpc.Core;
using GrpcExample;

Console.WriteLine("Setup Server...");
var server = new Server
{
    Services = { Example.BindService(new gRpcServer()) },
    Ports = { new ServerPort("127.0.0.1", 11111, ServerCredentials.Insecure) }
};
Console.WriteLine("Start Server...");
server.Start();

Console.WriteLine("Setup Client...");
var chnnel = new Channel("127.0.0.1", 11111, ChannelCredentials.Insecure);
var client = new Example.ExampleClient(chnnel);
Console.WriteLine("Get MachineInfo...");
var machineInfo = client.GetMachineInfo(new Google.Protobuf.WellKnownTypes.Empty());
Console.WriteLine($"MachineName: {machineInfo.MachineName} / UserName: {machineInfo.UserName}");


Console.WriteLine("Press any key to shutdown the server...");
Console.ReadKey();

server.ShutdownAsync().Wait();

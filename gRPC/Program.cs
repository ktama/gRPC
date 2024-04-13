// See https://aka.ms/new-console-template for more information
using gRPC;
using Grpc.Core;
using GrpcDevice;

Console.WriteLine("Setup Server...");
var server = new Server
{
    Services = { Device.BindService(new gRpcServer()) },
    Ports = { new ServerPort("127.0.0.1", 11111, ServerCredentials.Insecure) }
};
Console.WriteLine("Start Server...");
server.Start();

Console.WriteLine("Setup Client...");
var chnnel = new Channel("127.0.0.1", 11111, ChannelCredentials.Insecure);
var client = new Device.DeviceClient(chnnel);
Console.WriteLine("Get DeviceInfo...");
var deviceInfo = client.GetDeviceInfo(new Google.Protobuf.WellKnownTypes.Empty());
Console.WriteLine($"DeviceName: {deviceInfo.DeviceName} / UserName: {deviceInfo.UserName}");
Console.WriteLine("Get DeviceLog...");
var request = new DeviceLogRequest() { Level = 1 };
var deviceLog = client.GetDeviceLog(request);
Console.WriteLine($"LogLevel: {deviceLog.Level} / LogMessage: {deviceLog.Message}");
request = new DeviceLogRequest() { Level = 2 };
deviceLog = client.GetDeviceLog(request);
Console.WriteLine($"LogLevel: {deviceLog.Level} / LogMessage: {deviceLog.Message}");
request = new DeviceLogRequest() { Level = 3 };
deviceLog = client.GetDeviceLog(request);
Console.WriteLine($"LogLevel: {deviceLog.Level} / LogMessage: {deviceLog.Message}");

server.ShutdownAsync().Wait();

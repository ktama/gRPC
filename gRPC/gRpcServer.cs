using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcDevice;

namespace gRPC
{
    internal class gRpcServer : Device.DeviceBase
    {
        public override Task<DeviceInfoResponse> GetDeviceInfo(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new DeviceInfoResponse
            {
                DeviceName = Environment.MachineName,
                UserName = Environment.UserName
            });
        }
        public override Task<DeviceLogResponse> GetDeviceLog(DeviceLogRequest request, ServerCallContext context)
        {
            return Task.FromResult(new DeviceLogResponse
            {
                Level = request.Level,
                Message = $"Message{request.Level}"
            });
        }
    }
}

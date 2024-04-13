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

        public override Task<DeviceSysLogResponse> GetDeviceLog(DeviceSysLogRequest request, ServerCallContext context)
        {
            return Task.FromResult(new DeviceSysLogResponse
            {
                Ticks = DateTime.Now.Ticks,
                Level = request.Level,
                Message = $"Message{request.Level}"
            });
        }
    }
}

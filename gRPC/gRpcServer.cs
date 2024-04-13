using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcExample;

namespace gRPC
{
    internal class gRpcServer : Example.ExampleBase
    {
        public override Task<ExampleReply> GetMachineInfo(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new ExampleReply
            {
                MachineName = Environment.MachineName,
                UserName = Environment.UserName
            });
        }
    }
}

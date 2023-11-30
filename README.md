# gRPC for .NET Examples

Examples of basic gRPC scenarios with gRPC for .NET.

If you are brand new to gRPC on .NET a good place to start is the getting started tutorial: [Create a gRPC client and server in ASP.NET Core](https://docs.microsoft.com/aspnet/core/tutorials/grpc/grpc-start)

## [Greeter](https://github.com/ashuhatkar/ashulearn-grpc-v7.0.0/tree/main/src/Greeter)

The greeter shows how to create unary (non-streaming) gRPC methods in ASP.NET Core, and call them from a client.

##### Scenarios:

- Unary call

## [GrpcDb](https://github.com/ashuhatkar/ashulearn-grpc-v7.0.0/tree/main/src/GrpcDb)

The grpcdb shows how to create database unary (non-streaming) gRPC methods in ASP.NET Core, and call them from a client.

##### Scenarios:

- Unary call

## [Interceptor](https://github.com/ashuhatkar/ashulearn-grpc-v7.0.0/tree/main/src/Interceptor)

The interceptor shows how to use gRPC interceptors on the client and server. The client interceptor adds additional metadata to each call and the server interceptor logs that metadata on the server.

##### Scenarios:

- Creating a client interceptor
- Using a client interceptor
- Creating a server interceptor
- Using a server interceptor

## Service definition

Specifying the methods that can be called remotely with their parameters and return types. By default, gRPC uses protocol buffers as the Interface Definition Language (IDL) for describing both the service interface and the structure of the payload messages.

```proto
// The greeting service definition.
service Greeter {
  // Sends a greeting
  rpc SayHello (HelloRequest) returns (HelloReply);
  rpc SayHellos (HelloRequest) returns (stream HelloReply);
  rpc SayHelloToAll (stream HelloRequest) returns (HelloReply);
  rpc SayHellosToAll (stream HelloRequest) returns (stream HelloReply);
}

// The request message containing the user's name.
message HelloRequest {
  string name = 1;
}

// The response message containing the greetings.
message HelloReply {
  string message = 1;
}
```

gRPC lets you define four kinds of service method:

Unary RPCs where the client sends a single request to the server and gets a single response back

```proto
rpc SayHello (HelloRequest) returns (HelloReply);
```

Server streaming RPCs where the client sends a request to the server and gets a stream to read a sequence of messages back. The client reads from the returned stream until there are no more messages.

```proto
rpc SayHellos (HelloRequest) returns (stream HelloReply);
```

Client streaming RPCs where the client writes a sequence of messages and sends them to the server, again using a provided stream. Once the client has finished writing the messages, it waits for the server to read them and return its response.

```proto
rpc SayHelloToAll (stream HelloRequest) returns (HelloReply);
```

Bidirectional streaming RPCs where both sides send a sequence of messages using a read-write stream. The two streams operate independently, so clients and servers can read and write in whatever order they like:

```proto
rpc SayHellosToAll (stream HelloRequest) returns (stream HelloReply);
```

### Contribute

Contributions are welcome!

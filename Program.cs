//In the name of Allah

using Microsoft.EntityFrameworkCore;
using ServiceA.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<CityContext>(options => options.UseInMemoryDatabase("grpc-db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<CityServiceImpl>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

// protoc --csharp_out=output_directory --grpc_out=output_directory --plugin=protoc-gen-grpc=path/to/grpc_csharp_plugin your_file.proto


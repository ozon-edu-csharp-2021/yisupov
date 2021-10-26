using System.Threading;
using Grpc.Net.Client;
using OzonEdu.MerchandiseService.Grpc;

using var channel = GrpcChannel.ForAddress("http://localhost:5000");
var client = new MerchApiGrpc.MerchApiGrpcClient(channel);

var response = client.RequestMerch(new RequestMerchRequest(), cancellationToken: CancellationToken.None);

var response2 = client.GetRetrieveInformation(new GetRetrieveInformationRequest() {RetrieverId = 1}, cancellationToken: CancellationToken.None);
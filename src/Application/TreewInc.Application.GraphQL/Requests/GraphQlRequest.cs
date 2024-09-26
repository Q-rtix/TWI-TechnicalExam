using GraphQL.SystemTextJson;
using System.Text.Json.Serialization;

namespace TreewInc.Application.GraphQL.Requests;

public class GraphQlRequest
{
	public string Query { get; set; }
	
	[JsonConverter(typeof(ObjectDictionaryConverter))]
	public Dictionary<string, object> Variables { get; set; }
}

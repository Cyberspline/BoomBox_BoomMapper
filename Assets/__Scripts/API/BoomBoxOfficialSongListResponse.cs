using System.Collections.Generic;
using Newtonsoft.Json;

public class BoomBoxOfficialSongListResponse
{
    [JsonProperty("count")]
    public readonly int? Count;

    [JsonProperty("next")]
    public readonly string NextUrl;

    [JsonProperty("previous")]
    public readonly string PreviousUrl;

    [JsonProperty("results")]
    public readonly List<BoomBoxOfficialPack> OfficialPacks;

    public BoomBoxOfficialSongListResponse() { }
}

using Newtonsoft.Json;

public class BoomBoxOfficialPack : BoomBoxPackBase
{
    [JsonProperty("id")]
    public override int? SongId { get; set; }

    [JsonProperty("song_artist")]
    public override string SongArtist { get; set; }

    [JsonProperty("song_title")]
    public override string SongTitle { get; set; }

    [JsonProperty("song_duration")]
    public readonly float SongDuration;

    [JsonProperty("art_file")]
    public override string ImageFile { get; set; }

    [JsonProperty("music_file")]
    public override string AudioFile { get; set; }

    [JsonProperty("preview_file")]
    public readonly string PreviewFileUrl;

    // Purpose???
    [JsonProperty("dlc_pack")]
    public readonly int? DlcPack;
}

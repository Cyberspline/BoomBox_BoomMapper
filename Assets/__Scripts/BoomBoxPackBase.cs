using Newtonsoft.Json;

public abstract class BoomBoxPackBase
{
    public abstract int? SongId { get; set; }

    public abstract string SongArtist { get; set; }

    public abstract string SongTitle { get; set; }

    public abstract string ImageFile { get; set; }

    public abstract string AudioFile { get; set; }

    [JsonIgnore]
    public virtual bool IsFavourite { get; set; }
}

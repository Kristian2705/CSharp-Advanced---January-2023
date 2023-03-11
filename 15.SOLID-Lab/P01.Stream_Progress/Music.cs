namespace P01.Stream_Progress
{
    public class Music : IFile, IMusic
    {
        public Music(string artist, string album, int length, int bytesSent)
        {
            this.Artist = artist;
            this.Album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
    }
}

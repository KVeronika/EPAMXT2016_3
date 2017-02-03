namespace XT2016_3.Auction.Entities
{
    public class ImageData
    {
        public ImageData()
        {
        }
        public ImageData(byte[] data, string contentType)
        {
            this.Data = data;
            this.ContentType = contentType;
        }
        public int Id { get; set; }

        public byte[] Data { get; set; }

        public string ContentType { get; set; }
    }
}
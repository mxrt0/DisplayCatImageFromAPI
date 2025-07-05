namespace BackendHandler.Models
{
    public class CatImage
    {
       public CatImage(string url) 
        {
            ImageURL = url;
        }
        public string ImageURL { get; private set; }

    }
}

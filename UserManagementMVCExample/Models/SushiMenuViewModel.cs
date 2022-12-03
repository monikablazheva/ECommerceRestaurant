namespace UserManagementMVCExample.Models
{
    public class SushiMenuViewModel
    {
        public int SushiID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageThumbnailURL { get; set; }
        public bool IsFavourite { get; set; }

    }
}

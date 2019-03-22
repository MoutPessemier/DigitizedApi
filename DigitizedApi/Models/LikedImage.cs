namespace DigitizedApi.Models {
    public class LikedImage {
        #region Properties
        public int ImageId { get; set; }

        public int VisitorId { get; set; }

        public Visitor Visitor { get; set; }

        public MyImage Image { get; set; }
        #endregion
    }
}

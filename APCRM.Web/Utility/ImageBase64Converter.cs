namespace APCRM.Web.Utility
{
    public class ImageBase64Converter
    {
        public static string convertToByte(Stream inputstream)
        {
            string Base64string;
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(inputstream))
            {
                bytes = br.ReadBytes(Convert.ToInt32(inputstream.Length));
                Base64string = Convert.ToBase64String(bytes);
            }
            return Base64string;
        }

        // string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Data"]);
    }
}

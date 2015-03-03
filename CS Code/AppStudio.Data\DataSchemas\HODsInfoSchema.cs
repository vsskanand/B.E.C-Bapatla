using System;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the HODsInfoSchema class.
    /// </summary>
    public class HODsInfoSchema : BindableSchemaBase
    {
        private string _name;
        private string _email;
        private string _phone;
        private string _image;
         
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
 
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
 
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }
 
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        public override string DefaultTitle
        {
            get { return Name; }
        }

        public override string DefaultSummary
        {
            get { return null; }
        }

        public override string DefaultImageUrl
        {
            get { return Image; }
        }

        public override string DefaultContent
        {
            get { return null; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "name":
                        return String.Format("{0}", Name); 
                    case "email":
                        return String.Format("{0}", Email); 
                    case "phone":
                        return String.Format("{0}", Phone); 
                    case "image":
                        return String.Format("{0}", Image); 
                    case "defaulttitle":
                        return DefaultTitle;
                    case "defaultsummary":
                        return DefaultSummary;
                    case "defaultimageurl":
                        return DefaultImageUrl;
                    default:
                        break;
                }
            }
            return String.Empty;
        }
    }
}

using System;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the FacilitiesSchema class.
    /// </summary>
    public class FacilitiesSchema : BindableSchemaBase
    {
        private string _image;
        private string _label;
        private string _name;
        private string _description;
         
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
 
        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }
 
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
 
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public override string DefaultTitle
        {
            get { return Label; }
        }

        public override string DefaultSummary
        {
            get { return Name; }
        }

        public override string DefaultImageUrl
        {
            get { return Image; }
        }

        public override string DefaultContent
        {
            get { return Name; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "image":
                        return String.Format("{0}", Image); 
                    case "label":
                        return String.Format("{0}", Label); 
                    case "name":
                        return String.Format("{0}", Name); 
                    case "description":
                        return String.Format("{0}", Description); 
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

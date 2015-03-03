﻿using System.Collections.Generic;
using System.Text;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Controls;

namespace AppStudio.Controls.Html2Xaml
{
    /// <summary>
    /// Usage: 
    /// 1) In a XAML file, declare the above namespace, e.g.:
    ///    xmlns:h2xaml="using:Html2Xaml"
    ///     
    /// 2) In RichTextBlock controls, set or databind the Html property, e.g.:
	///    <RichTextBlock h2xaml:Properties.Html="{Binding ...}"/>
    ///    or
    ///    <RichTextBlock>
	///     <h2xaml:Properties.Html>
    ///         <![CDATA[
    ///             <p>This is a list:</p>
    ///             <ul>
    ///                 <li>Item 1</li>
    ///                 <li>Item 2</li>
    ///                 <li>Item 3</li>
    ///             </ul>
    ///         ]]>
	///     </h2xaml:Properties.Html>
    /// </RichTextBlock>
    /// </summary>
    public class Properties : DependencyObject
    {
        public static readonly DependencyProperty HtmlProperty =
            DependencyProperty.RegisterAttached("Html", typeof(string), typeof(Properties), new PropertyMetadata(null, HtmlChanged));

        public static void SetHtml(DependencyObject obj, string value)
        {
            obj.SetValue(HtmlProperty, value);
        }

        public static string GetHtml(DependencyObject obj)
        {
            return (string)obj.GetValue(HtmlProperty);
        }

		public static Dictionary<string, Dictionary<string, string>> TagAttributes = null;
		private static void HtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is RichTextBlock)
			{
				string html = e.NewValue as string;
			
                RichTextBlock richText = d as RichTextBlock;
				if (richText == null) return;

				richText.Blocks.Clear();
			
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("<?xml version=\"1.0\"?>");            
				sb.AppendLine("<RichTextBlock xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">");
                sb.AppendLine(Html2XamlConverter.Convert2Xaml(html, TagAttributes));       
				sb.AppendLine("</RichTextBlock>");
       
                RichTextBlock newRichText = (RichTextBlock)XamlReader.Load(sb.ToString());
				
				for (int i = newRichText.Blocks.Count - 1; i >= 0; i--)
				{
					Block b = newRichText.Blocks[i];
					newRichText.Blocks.RemoveAt(i);
					richText.Blocks.Insert(0, b);
				}
			}
		}
    }
}

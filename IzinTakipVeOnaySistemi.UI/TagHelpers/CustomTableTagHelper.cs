using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections;
using System.Reflection;
using System.Text;

namespace IzinTakipVeOnaySistemi.UI.TagHelpers
{
    [HtmlTargetElement("custom-table")]
    public class CustomTableTagHelper : TagHelper
    {
        public IEnumerable Items { get; set; } //items = "Model" , Tabloya gönderilen veri listesi
        public string ControllerName { get; set; }
        public string Columns { get; set; } //Id:ID, Ad:Adı, Eposta:E-posta

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.Attributes.SetAttribute("class", "table table-bordered");

            var columnDefs = Columns.Split(',')
                .Select(c =>
                {
                    var parts = c.Split(":");
                    return new
                    {
                        Property = parts[0].Trim(),
                        Header = parts.Length > 1 ? parts[1].Trim() : parts[0].Trim()
                    };
                })
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine("<thead><tr>");

            foreach (var col in columnDefs)
            {
                sb.AppendLine($"<th>{col.Header}</th>");
            }

            sb.AppendLine("<th>İşlemler</th>");
            sb.AppendLine("</tr></thead>");

            sb.AppendLine("<tbody>");

            foreach (var item in Items)
            {
                var type = item.GetType();
                sb.AppendLine("<tr>");

                foreach (var col in columnDefs)
                {
                    object value = item;
                    foreach (var prop in col.Property.Split(".")) //Musteri.Ad gibiyse ayırır
                    {
                        if (value == null) { break; }

                        var pi = value.GetType().GetProperty(prop);
                        value = pi?.GetValue(value); //Musteri.Ad değerini döndürür. ÖR : Berkay
                    }
                    sb.AppendLine($"<td>{value}</td>");
                }
                var idProp = type.GetProperty("Id"); //Modelin tipinden Id adındaki propu bulur
                var idVal = idProp?.GetValue(item); //Bulduğu Id propunun değerini alır

                sb.AppendLine("<td>");
                sb.AppendLine($"<a href='/{ControllerName}/Edit/{idVal}' class='btn btn-success'>Düzenle</a>");
                sb.AppendLine($"<a href='/{ControllerName}/Delete/{idVal}' class='btn btn-danger' onclick = \"return confirm ('Silmek istediğinize emin misiniz?')\">Sil</a>");
                sb.AppendLine("<td>");
                sb.AppendLine("</tr>");
            }
            sb.AppendLine("</tbody>");
            output.Content.SetHtmlContent(sb.ToString());
        }

    }
}

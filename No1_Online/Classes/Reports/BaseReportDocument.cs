using No1_Online.ViewModels;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace No1_Online.Classes.Reports
{
    public abstract class BaseReportDocument : IDocument
    {
        public ReportsVM Model { get; }
        public abstract string Title { get; }
        public string OptionalText { get; set; } // Optional text property
        public abstract void ComposeTable(IContainer container);
        public virtual void ComposeFooter(IContainer container) { }

        protected BaseReportDocument(ReportsVM model, string optionalText = null)
        {
            Model = model;
            OptionalText = optionalText;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(30);
                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().Element(ComposeFooter);
                });
        }

        void ComposeHeader(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(16).SemiBold().FontColor(Colors.Black);

            container.Column(column =>
            {
                column.Item().Row(row =>
                {
                    row.RelativeItem().ShowOnce().Column(innerColumn =>
                    {
                        innerColumn.Item().Text(Title).Style(titleStyle);

                        

                    });

                    string logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PNG", "no1_new_logo.png");
                    if (File.Exists(logoPath))
                    {
                        row.RelativeItem().Image(logoPath);
                    }
                    else
                    {
                        row.RelativeItem().Text("Logo not found").FontColor(Colors.Red.Medium);
                    }
                });

                // Divider
                column.Item().PaddingVertical(10).LineHorizontal(1);
                if (!string.IsNullOrEmpty(OptionalText))
                {
                    column.Item().ShowOnce().Text(OptionalText).FontSize(12).FontColor(Colors.Grey.Darken2);
                }
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(20).Column(column =>
            {
                column.Spacing(5);
                column.Item().Element(ComposeTable);
                column.Item().PaddingTop(20).Element(ComposeComments);
            });
        }

        void ComposeComments(IContainer container)
        {
            container.Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Comments").FontSize(12);
                column.Item().Text("Additional comments can be added here.").FontSize(10);
            });
        }
    }
}

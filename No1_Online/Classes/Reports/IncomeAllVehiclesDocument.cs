using No1_Online.ViewModels;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace No1_Online.Classes.Reports
{
    public class IncomeAllVehiclesDocument : BaseReportDocument
    {
        private Task<ReportsVM> viewModel;
        private object value;

        public IncomeAllVehiclesDocument(ReportsVM model, string? optionalText = null) : base(model, optionalText) { }

        

        public override string Title => "All Vehicles: Income Report";

        public override void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("Load Number");
                    header.Cell().Element(CellStyle).Text("Client");
                    header.Cell().Element(CellStyle).AlignRight().Text("Date");
                    header.Cell().Element(CellStyle).AlignRight().Text("Loading Point");
                    header.Cell().Element(CellStyle).AlignRight().Text("Destination");
                    header.Cell().Element(CellStyle).AlignRight().Text("Total Value");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold().FontSize(10)).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                foreach (var item in Model.loadingSchedules)
                {
                    table.Cell().Element(CellStyle).Text($"{item.Id}");
                    table.Cell().Element(CellStyle).Text(item.Company.Name);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Date:d}");
                    table.Cell().Element(CellStyle).AlignRight().Text(item.LoadingPointLoad.City);
                    table.Cell().Element(CellStyle).AlignRight().Text(item.LoadingPointOff.City);
                    table.Cell().Element(CellStyle).AlignRight().Text($"R{item.Value:N}");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.FontSize(9)).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                    }
                }
            });
        }

        public override void ComposeFooter(IContainer container)
        {
            container.AlignCenter().Text(x =>
            {
                x.CurrentPageNumber();
                x.Span(" / ");
                x.TotalPages();
            });
        }

        public byte[] GeneratePdf()
        {
            return Document.Create(container => Compose(container)).GeneratePdf();
        }
    }
}

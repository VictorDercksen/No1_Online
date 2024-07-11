using QuestPDF.Infrastructure;

namespace No1_Online.Interfaces
{
    public interface IDocument
    {
        DocumentMetadata GetMetadata();
        DocumentSettings GetSettings();
        void Compose(IDocumentContainer container);
    }
}

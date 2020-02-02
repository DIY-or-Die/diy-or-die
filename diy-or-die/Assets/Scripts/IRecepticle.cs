
public interface IRecepticle
{
    Droppable Item { get; set; }
    bool UsesPart { get; }

    void ReceiveItem(Droppable item);

    void ReleaseItem();
}

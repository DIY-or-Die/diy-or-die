
public interface IRecepticle
{
    Droppable Item { get; set; }

    void ReceiveItem(Droppable item);

    void ReleaseItem();
}

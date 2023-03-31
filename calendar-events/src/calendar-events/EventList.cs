namespace calendar_events;
#pragma warning disable CS8602

public class EventList
{
    private class Node
    {
        public Event Value;
        public Node? Next;

        public Node(Event t)
        {
            Value = t;
            Next = null;
        }
    }

    private Node? Head;

    public void GenericList()
    {
        Head = null;
    }

    public void Add(Event input)
    {
        if (Head == null)
        {
            Head = new Node(input);
        }
        else
        {
            //Encontra onde inserir o próximo nó na lista.
            Node? lastNode = Head;
            while (lastNode.Next != null) lastNode = lastNode.Next;

            lastNode.Next = new Node(input);
        }
    }

    public void Print(string format)
    {
        Node? printNode = Head;
        while (printNode.Next != null)
        {

        }

    }

    public Event Index(int index)
    {
        Node? searchNode = Head;
        for (int i = 0; i < index; i++)
        {
            if (searchNode.Next != null)
            {
                searchNode = searchNode.Next;
                continue;
            }
            else
            {
                throw new InvalidOperationException("Não há elementos suficientes na lista");
            }
        }
        return searchNode.Value;
    }

    public int SearchByTitle(string title)
    {
        Node actualNode = Head;
        int count = 0;

        if (actualNode == null) throw new InvalidOperationException("Não há elementos suficientes na lista");
        while (actualNode.Value.Title != title && actualNode.Next != null)
        {
            actualNode = actualNode.Next;
            count += 1;
        }
        if (actualNode.Value.Title == title) return count;
        else return -1;
    }

    public int SearchByDate(string dateSearch)
    {
        Node actualNode = Head;
        int count = 0;

        if (actualNode == null) throw new InvalidOperationException("Não há elementos suficientes na lista");
        while (actualNode.Value.EventDate != DateTime.Parse(dateSearch) && actualNode.Next != null)
        {
            actualNode = actualNode.Next;
            count += 1;
        }
        if (actualNode.Value.EventDate == DateTime.Parse(dateSearch)) return count;
        else return -1;
    }

}
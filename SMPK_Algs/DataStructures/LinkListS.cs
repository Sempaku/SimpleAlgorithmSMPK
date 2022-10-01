namespace SMPK_Algs.DataStructures
{
    public class LinkListS
    {
        private Link first;

        public LinkListS() => this.first = null;

        public bool isEmpty() => first == null;

        public void InsertFirst(Link link)
        {
            link.next = first;
            first = link;
        }

        public void InsertAfterKey(Link newLink, int key)
        {
            Link link = first;
            while (link != null)
            {
                if (link.key == key)
                {
                    newLink.next = link.next;
                    link.next = newLink;
                }
                else
                {
                    link = link.next;
                }
            }
            if (link == null)
            {
                newLink.next = first;
                first = newLink;
            }
        }

        public Link FindByKey(int key)
        {
            Link link = first;
            while (key != null)
            {
                if (link.key == key)
                    return link;
                else
                    link = link.next;
            }
            return null;
        }

        public Link DeleteFirst()
        {
            if (first != null)
            {
                Link link = first;
                first = first.next;
                return link;
            }
            else
                return null;
        }

        public Link DeleteByKey(int key)
        {
            Link prevLink = null;
            Link currentLink = first;
            while (currentLink != null)
            {
                if (currentLink != null)
                    if (currentLink == first)
                        first = currentLink.next;
                    else
                        prevLink.next = currentLink.next;
                else
                {
                    prevLink = currentLink;
                    currentLink = currentLink.next;
                }
            }
            return null;
        }

        public override string ToString()
        {
            string display = "";
            Link link = first;
            while (link != null)
            {
                display += link.ToString() + " ";
                link = link.next;
            }
            return display.Trim();
        }

        public class Link
        {
            public int key;
            public double value;
            public Link next;

            public Link(int key, double value)
            {
                this.key = key;
                this.value = value;
                this.next = null;
            }

            public override string ToString()
            {
                return $"{key}={value};";
            }
        }
    }
}